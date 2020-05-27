FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build-env

WORKDIR /app

EXPOSE 80

COPY . ./

RUN dotnet restore
RUN dotnet publish ./FavoDeMel.Api/FavoDeMel.Api.csproj -c Release -o ./FavoDeMel.Api/build --no-restore

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic AS runtime

WORKDIR /app

COPY --from=build-env /app/FavoDeMel.Api/build ./

ENTRYPOINT ["dotnet", "FavoDeMel.Api.dll"]