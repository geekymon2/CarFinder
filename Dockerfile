FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

#copy the projects and restore
COPY ["Cars.API/Cars.Api.csproj", "Cars.API/"]
COPY ["Cars.DAL/Cars.DAL.csproj", "Cars.DAL/"]
RUN dotnet restore "Cars.API/Cars.Api.csproj"

#copy everything else and build
COPY . .
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM publish AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY entrypoint.sh ./entrypoint.sh
RUN chmod +x ./entrypoint.sh
#CMD /bin/bash ./entrypoint.sh