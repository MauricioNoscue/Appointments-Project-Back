# =========================================================
# 🧱 BASE IMAGE (ASP.NET Runtime)
# =========================================================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

RUN apt-get update && apt-get install -y mssql-tools unixodbc-dev && rm -rf /var/lib/apt/lists/*
ENV PATH="$PATH:/opt/mssql-tools/bin"

WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# =========================================================
# 🛠️ BUILD IMAGE (compila el proyecto)
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
RUN dotnet build "./Web_back.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 🧠 Aquí instalamos EF y aplicamos migraciones directamente
RUN dotnet tool install --global dotnet-ef --version 8.0.0 \
    && export PATH="$PATH:/root/.dotnet/tools" \
    && dotnet ef database update --project ../Entity-Back/Entity-Back.csproj --startup-project ./Web_back.csproj


# =========================================================
# 📦 PUBLISH IM
# =========================================================
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Web_back.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false


# =========================================================
# 🚀 FINAL IMAGE
# =========================================================
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Web_back.dll"]
