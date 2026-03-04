# 1. Build Stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy project files for restore (this speeds up builds on Render)
COPY ["SmartPortfolio.API/SmartPortfolio.API.csproj", "SmartPortfolio.API/"]
COPY ["SmartPortfolio.Domain/SmartPortfolio.Domain.csproj", "SmartPortfolio.Domain/"]
COPY ["SmartPortfolio.Application/SmartPortfolio.Application.csproj", "SmartPortfolio.Application/"]
COPY ["SmartPortfolio.Persistance/SmartPortfolio.Persistance.csproj", "SmartPortfolio.Persistance/"]

RUN dotnet restore "SmartPortfolio.API/SmartPortfolio.API.csproj"

# Copy everything else and publish
COPY . .
WORKDIR "/src/SmartPortfolio.API"
RUN dotnet publish "SmartPortfolio.API.csproj" -c Release -o /app/publish

# 2. Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .

# Environment setup for Render
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "SmartPortfolio.API.dll"]