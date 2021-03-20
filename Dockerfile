#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Cars.API/Cars.Api.csproj", "Cars.API/"]
COPY ["Cars.DAL/Cars.DAL.csproj", "Cars.DAL/"]
RUN dotnet restore "Cars.API/Cars.Api.csproj"
COPY . .
WORKDIR "/src/Cars.API"
RUN dotnet build "Cars.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cars.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cars.Api.dll"]