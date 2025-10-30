# ==========================================================
# 🏗️ Etapa base (runtime)
# ==========================================================
FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy AS base
WORKDIR /app
EXPOSE 8080

# ==========================================================
# ⚙️ Etapa de build
# ==========================================================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar archivos de proyecto individuales (para cachear el restore)
COPY Business-Back/Business-Back.csproj Business-Back/
COPY Data-Back/Data-Back.csproj Data-Back/
COPY Entity-Back/Entity-Back.csproj Entity-Back/
COPY Utilities-Back/Utilities-Back.csproj Utilities-Back/
COPY Web_back/Web_back.csproj Web_back/
COPY Appointments-Project-Back.sln .

# Restaurar dependencias
RUN dotnet restore "Web_back/Web_back.csproj"

# Copiar todo el código fuente
COPY . .

# Compilar
WORKDIR /src/Web_back
RUN dotnet build "Web_back.csproj" -c $BUILD_CONFIGURATION -o /app/build

# ==========================================================
# 🚀 Etapa de publicación
# ==========================================================
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Web_back.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# ==========================================================
# 🧩 Imagen final (runtime)
# ==========================================================
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# ==========================================================
# ▶️ Entrada del contenedor
# ==========================================================
ENTRYPOINT ["dotnet", "Web_back.dll"]
