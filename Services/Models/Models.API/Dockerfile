FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Services/Models/Models.API/Models.API.csproj", "Services/Models/Models.API/"]
COPY ["BuildingBlocks/SeedWork/SeedWork.csproj", "BuildingBlocks/SeedWork/"]
COPY ["BuildingBlocks/Utils/Utils.csproj", "BuildingBlocks/Utils/"]
COPY ["BuildingBlocks/Common/Common.csproj", "BuildingBlocks/Common/"]
COPY ["Services/Models/Models.Domain/Models.Domain.csproj", "Services/Models/Models.Domain/"]
COPY ["Services/Models/Models.Infrastructure/Models.Infrastructure.csproj", "Services/Models/Models.Infrastructure/"]
COPY ["Config/Config.csproj", "Config/"]
RUN dotnet restore "Services/Models/Models.API/"
COPY . .
WORKDIR "/src/Services/Models/Models.API"
RUN dotnet build "Models.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Models.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Models.API.dll"]
