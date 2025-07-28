FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY *.sln ./
COPY url-shortener/*.csproj ./url-shortener/
COPY url-shortener.Application/*.csproj ./url-shortener.Application/
COPY url-shortener.Data/*.csproj ./url-shortener.Data/
COPY url-shortener.Domain/*.csproj ./url-shortener.Domain/
COPY url-shortener.Projection/*.csproj ./url-shortener.Projection/
RUN dotnet restore

COPY . .
WORKDIR /src/url-shortener
RUN dotnet publish -c Release -o /app/publish /p:EnvironmentName=Development --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "url-shortener.dll"]
