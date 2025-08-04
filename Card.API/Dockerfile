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
COPY ["Card.API/Card.API.csproj", "Card.API/"]
COPY ["Card.Application/Card.Application.csproj", "Card.Application/"]
COPY ["Card.Domain/Card.Domain.csproj", "Card.Domain/"]
COPY ["Card.Infrastructure/Card.Infrastructure.csproj", "Card.Infrastructure/"]
COPY ["Shared/Shared.csproj", "Shared/"]

RUN sleep 10

# Restaura os pacotes
RUN dotnet restore "./Card.API/Card.API.csproj"

# Copia os arquivos de código
COPY . .

# Compila
WORKDIR /src/Card.API
RUN dotnet build "./Card.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publica
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Card.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Runtime
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Card.API.dll"]