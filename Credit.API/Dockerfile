# Base da aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Fase de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia apenas os .csproj dos projetos usados
COPY ["Credit.API/Credit.API.csproj", "Credit.API/"]
COPY ["Credit.Application/Credit.Application.csproj", "Credit.Application/"]
COPY ["Credit.Domain/Credit.Domain.csproj", "Credit.Domain/"]
COPY ["Credit.Infrastructure/Credit.Infrastructure.csproj", "Credit.Infrastructure/"]
COPY ["Shared/Shared.csproj", "Shared/"]

RUN sleep 5

# Restaura os pacotes
RUN dotnet restore "./Credit.API/Credit.API.csproj"

# Copia os arquivos de código (após restore dos .csproj)
COPY . .

# Compila
WORKDIR /src/Credit.API
RUN dotnet build "./Credit.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publica
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Credit.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Runtime
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Credit.API.dll"]