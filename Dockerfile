FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Cars.API/Cars.Api.csproj", "./"]
COPY ["Cars.DAL/Cars.DAL.csproj", "./"]
RUN dotnet restore "Cars.Api.csproj"
RUN dotnet restore "Cars.DAL.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Cars.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cars.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cars.Api.dll"]