# ===== Build =====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia .sln y los .csproj para restaurar
COPY *.sln ./
COPY Web_back/Web_back.csproj Web_back/
COPY Business-Back/Business-Back.csproj Business-Back/
COPY Data-Back/Data-Back.csproj Data-Back/
COPY Entity-Back/Entity-Back.csproj Entity-Back/
COPY Utilities-Back/Utilities-Back.csproj Utilities-Back/

RUN dotnet restore Web_back/Web_back.csproj

# Copia todo y publica
COPY . .
WORKDIR /src/Web_back
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# ===== Runtime =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
COPY --from=build /app/publish ./
ENTRYPOINT ["dotnet", "Web_back.dll"]
