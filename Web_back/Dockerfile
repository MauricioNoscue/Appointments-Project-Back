# CREAR IMAGEN (Ref Web_back): docker build -t hospital_teruel_back -f Dockerfile ..

# Usa la imagen oficial de .NET SDK 8.0 para compilar la aplicación (fase de build)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Define el directorio de trabajo dentro del contenedor para la compilación
WORKDIR /docker_backend


# Copia los archivos de proyecto (.csproj) y sus carpetas correspondientes
COPY ["Web_back/Web_back.csproj", "Web_back/"]
COPY ["Entity-Back/Entity-Back.csproj", "Entity-Back/"]
COPY ["Data-Back/Data-Back.csproj", "Data-Back/"]
COPY ["Business-Back/Business-Back.csproj", "Business-Back/"]
COPY ["Utilities-Back/Utilities-Back.csproj", "Utilities-Back/"]


# Restaura las dependencias de NuGet de todos los proyectos
RUN dotnet restore "Web_back/Web_back.csproj"


# Copia el resto del código fuente de la solución al contenedor
COPY . .
# Cambia el directorio de trabajo al proyecto Web_back (punto de entrada de la app)
WORKDIR /docker_backend/Web_back
# Compila y publica la aplicación en modo Release en la carpeta /app/out dentro del contenedor
RUN dotnet publish -c Release -o /app/out


# ------------------------------------------------------------
# Fase final (runtime): imagen ligera solo para ejecutar la app
# ------------------------------------------------------------

# Usa la imagen oficial de .NET Runtime (ASP.NET Core 8.0) para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0
# Define el directorio de trabajo dentro del contenedor para la ejecución
WORKDIR /app
# Copia los archivos publicados de la fase "build" a este contenedor
COPY --from=build /app/out .
# Define el comando de entrada que ejecutará la aplicación
ENTRYPOINT ["dotnet", "Web_back.dll"]

# CREAR CONTENEDOR: docker run -d -p 7011:7011 --name cnt_codexy_backend --network data-Backbases_db_network codexy_backend