# Imagen base para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar la solución y restaurar dependencias
COPY trabajo-final-api-rest.sln .
COPY trabajo-final-api-rest/ ./trabajo-final-api-rest/

RUN dotnet restore trabajo-final-api-rest.sln

# Compilar en modo Release
RUN dotnet publish trabajo-final-api-rest/trabajo-final-api-rest.csproj -c Release -o /app/publish

# Imagen final (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

# Puerto por defecto del contenedor
EXPOSE 8080

# Comando de arranque
ENTRYPOINT ["dotnet", "trabajo-final-api-rest.dll"]
