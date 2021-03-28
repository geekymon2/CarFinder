# Base image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
LABEL maintainer="geekymon2@gmail.com"
WORKDIR /app
EXPOSE 5000
EXPOSE 2222 80
ENV ASPNETCORE_URLS=http://*:5000
ENV ASPNETCORE_ENVIRONMENT=Development

# Assemble and run the build
# Restore is run on the solution file to restore all projects.
# Build is run on Cars.API project. 
# This projects has dependency on other projects.
# Build output contains all required binaries.
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ARG Configuration=Release
WORKDIR /src
COPY *.sln ./
COPY ["Cars.API/Cars.Api.csproj", "Cars.API/"]
COPY ["Cars.DAL/Cars.DAL.csproj", "Cars.DAL/"]
COPY ["Cars.EF.Migrations/Cars.EF.Migrations.csproj", "Cars.EF.Migrations/"]
RUN dotnet restore
COPY . .
WORKDIR "/src/Cars.API"
RUN dotnet build -c ${Configuration} -o /app/build

# Publish
FROM build AS publish
ARG Configuration=Release
RUN dotnet publish -c ${Configuration} -o /app/publish

# Final image
# Copy build/published artifacts
FROM base AS final
WORKDIR /app
COPY --from=build /app/build/ /app/
COPY --from=publish /app/publish /publish/
# Copy the sshd_config file to the /etc/ssh/ directory
COPY sshd_config /etc/ssh/
COPY entrypoint.sh ./entrypoint.sh
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh