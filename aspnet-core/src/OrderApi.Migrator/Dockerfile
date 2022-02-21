#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/OrderApi.Migrator/OrderApi.Migrator.csproj", "src/OrderApi.Migrator/"]
COPY ["src/OrderApi.EntityFrameworkCore/OrderApi.EntityFrameworkCore.csproj", "src/OrderApi.EntityFrameworkCore/"]
COPY ["src/OrderApi.Core/OrderApi.Core.csproj", "src/OrderApi.Core/"]
COPY ["src/OrderApi.Core.Shared/OrderApi.Core.Shared.csproj", "src/OrderApi.Core.Shared/"]
RUN dotnet restore "src/OrderApi.Migrator/OrderApi.Migrator.csproj"
COPY . .
WORKDIR "/src/src/OrderApi.Migrator"
RUN dotnet build "OrderApi.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderApi.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderApi.Migrator.dll", "-s"]
