# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY CampusCuisine.Shared/*.csproj ./CampusCuisine.Shared/
COPY CampusCuisine.Api/*.csproj ./CampusCuisine.Api/
RUN dotnet restore CampusCuisine.Api

# copy everything else and build app
COPY CampusCuisine.Shared/. ./CampusCuisine.Shared/
COPY CampusCuisine.Api/. ./CampusCuisine.Api/
RUN dotnet publish CampusCuisine.Api -c release -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "CampusCuisine.Api.dll"]
