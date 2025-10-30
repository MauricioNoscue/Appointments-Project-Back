# =========================================================
# 🧱 BASE IMAGE (ASP.NET Runtime)
# =========================================================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# 🔧 Instalar herramientas SQL necesarias (sqlcmd, ODBC, etc.)
RUN apt-get update \
    && apt-get install -y curl apt-transport-https gnupg \
    && curl -sSL https://packages.microsoft.com/keys/microsoft.asc | apt-key add - \
    && curl -sSL https://packages.microsoft.com/config/debian/12/prod.list -o /etc/apt/sources.list.d/mssql-release.list \
    && apt-get update \
    && ACCEPT_EULA=Y apt-get install -y mssql-tools18 unixodbc-dev \
    && rm -rf /var/lib/apt/lists/*

# Añadir sqlcmd al PATH
ENV PATH="$PATH:/opt/mssql-tools18/bin"

WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# =========================================================
# 🛠️ BUILD IMAGE (compila el proyecto y aplica migraciones)
# =========================================================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar los proyectos
COPY ["Web_back/Web_back.csproj", "Web_back/"]
COPY ["Business-Back/Business-Back.csproj", "Business-Back/"]
COPY ["Data-Back/Data-Back.csproj", "Data-Back/"]
COPY ["Entity-Back/Entity-Back.csproj", "Entity-Back/"]
COPY ["Utilities-Back/Utilities-Back.csproj", "Utilities-Back/"]

# Restaurar dependencias
RUN dotnet restore "./Web_back/Web_back.csproj"

# Copiar todo el código y compilar
COPY . .
WORKDIR "/src/Web_back"
RUN dotnet build "./Web_back.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 🧠 Instalar EF Core y ejecutar migraciones
RUN dotnet tool install --global dotnet-ef --version 8.0.0 \
    && export PATH="$PATH:/root/.dotnet/tools" \
    && dotnet-ef database update \
        --project ../Entity-Back/Entity-Back.csproj \
        --startup-project ./Web_back.csproj


# =========================================================
# 📦 PUBLISH IMAGE
# =========================================================
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Web_back.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false


# =========================================================
# 🚀 FINAL IMAGE (runtime)
# =========================================================
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Web_back.dll"]
