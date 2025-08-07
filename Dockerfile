FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY TestWebApp/TestWebApp.sln ./
COPY TestWebApp/TestWebApp.csproj TestWebApp/
COPY TestWebAppLib/TestWebAppLib.csproj TestWebAppLib/
RUN dotnet restore
COPY . ./
RUN dotnet publish TestWebApp.sln -c Release -o /app/publish
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "TestWebApp.dll"]