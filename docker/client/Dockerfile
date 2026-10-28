# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY CampusCuisine.Shared/*.csproj ./CampusCuisine.Shared/
COPY CampusCuisine.Client/*.csproj ./CampusCuisine.Client/
RUN dotnet restore CampusCuisine.Client

# copy everything else and publish the app
COPY CampusCuisine.Shared/. ./CampusCuisine.Shared/
COPY CampusCuisine.Client/. ./CampusCuisine.Client/
RUN dotnet publish CampusCuisine.Client -c release -o /app

# final stage/image: only static files, served by nginx
FROM nginx:1.29-alpine
COPY docker/client/nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=build /app/wwwroot /usr/share/nginx/html
