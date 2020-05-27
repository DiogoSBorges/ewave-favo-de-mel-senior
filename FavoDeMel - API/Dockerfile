FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build-env

WORKDIR /app

EXPOSE 80

COPY . ./

RUN dotnet restore
RUN dotnet publish ./FavoDeMel.Web.Api/FavoDeMel.Web.Api.csproj -c Release -o ./FavoDeMel.Web.Api/build --no-restore

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic AS runtime

WORKDIR /app

COPY --from=build-env /app/FavoDeMel.Web.Api/build ./

ENTRYPOINT ["dotnet", "FavoDeMel.Web.Api.dll"]