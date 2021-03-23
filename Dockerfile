#base image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
LABEL maintainer="geekymon2@gmail.com"
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000
ENV ASPNETCORE_ENVIRONMENT=Development

#assemble build tools and run build
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
COPY ["Cars.EF.Migrations/Cars.EF.Migrations.csproj", "Cars.EF.Migrations/"]
RUN dotnet restore
COPY . .
WORKDIR "/src/Cars.API"
RUN dotnet build -c ${Configuration} -o /app/build

#entityframework migrations project
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS migration
ARG Configuration=Release
WORKDIR /src
COPY *.sln ./
COPY ["Cars.API/Cars.Api.csproj", "Cars.API/"]
COPY ["Cars.DAL/Cars.DAL.csproj", "Cars.DAL/"]
COPY ["Cars.EF.Migrations/Cars.EF.Migrations.csproj", "Cars.EF.Migrations/"]
RUN dotnet restore
COPY . .
WORKDIR "/src/Cars.EF.Migrations"
RUN dotnet build -c ${Configuration} -o /app/migration

#publish
FROM build AS publish
ARG Configuration=Release
RUN dotnet publish -c ${Configuration} -o /app/publish

#final image
#copy published artifacts
#copy source for ef database update
FROM base AS final
WORKDIR /migration
COPY --from=migration /app/migration .
WORKDIR /app
ENV PATH="${PATH}:/root/.dotnet/tools"
COPY --from=build /src/*.* /app/src/
COPY --from=publish /app/publish .
COPY --from=publish /root/.dotnet/tools /root/.dotnet/tools
ENTRYPOINT ["dotnet", "Cars.Api.dll"]