FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY NewTestApp.sln ./
COPY TestWebApp/TestWebApp.csproj TestWebApp/
COPY TestWebAppLib/TestWebAppLib.csproj TestWebAppLib/
RUN dotnet restore NewTestApp.sln
COPY . ./
RUN dotnet publish NewTestApp.sln -c Release -o /app/publish
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
#Set the environment variable to Production
ENV ASPNETCORE_ENVIRONMENT=Development
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "TestWebApp.dll"]