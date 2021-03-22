FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#install dotnet ef tools
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"
RUN dotnet ef
ARG Configuration=Release
WORKDIR /src
COPY *.sln ./
COPY ["Cars.API/Cars.Api.csproj", "Cars.API/"]
COPY ["Cars.DAL/Cars.DAL.csproj", "Cars.DAL/"]
RUN dotnet restore
COPY . .
WORKDIR "/src/Cars.API"
RUN dotnet build -c ${Configuration} -o /app/build

FROM build AS publish
ARG Configuration=Release
RUN dotnet publish -c ${Configuration} -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY entrypoint.sh ./entrypoint.sh

#change permissions and execute
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh