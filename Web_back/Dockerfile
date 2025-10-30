# =========================================================
# 🧱 BASE IMAGE (ASP.NET Runtime)
# =========================================================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Instalar herramientas SQL necesarias
# 🔧 Instalar herramientas SQL (versión corregida para Debian 12)
RUN apt-get update \
    && apt-get install -y curl apt-transport-https gnupg2 software-properties-common \
    && mkdir -p /etc/apt/keyrings \
    && curl -sSL https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > /etc/apt/keyrings/microsoft.gpg \
    && echo "deb [arch=amd64 signed-by=/etc/apt/keyrings/microsoft.gpg] https://packages.microsoft.com/debian/12/prod bookworm main" > /etc/apt/sources.list.d/mssql-release.list \
    && apt-get update \
    && ACCEPT_EULA=Y apt-get install -y mssql-tools18 unixodbc-dev \
    && rm -rf /var/lib/apt/lists/* 
ENV PATH="$PATH:/opt/mssql-tools18/bin"

WORKDIR /app
EXPOSE 8080

# =========================================================
# 🛠️ BUILD IMAGE (solo compila y publica)
# =========================================================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Web_back/Web_back.csproj", "Web_back/"]
COPY ["Business-Back/Business-Back.csproj", "Business-Back/"]
COPY ["Data-Back/Data-Back.csproj", "Data-Back/"]
COPY ["Entity-Back/Entity-Back.csproj", "Entity-Back/"]
COPY ["Utilities-Back/Utilities-Back.csproj", "Utilities-Back/"]
RUN dotnet restore "./Web_back/Web_back.csproj"

COPY . .
WORKDIR "/src/Web_back"
RUN dotnet publish "./Web_back.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# =========================================================
# 🚀 FINAL IMAGE (runtime)
# =========================================================
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Web_back.dll"]
