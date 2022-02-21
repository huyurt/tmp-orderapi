#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/OrderApi.Web.Public/OrderApi.Web.Public.csproj", "src/OrderApi.Web.Public/"]
COPY ["src/OrderApi.Web.Core/OrderApi.Web.Core.csproj", "src/OrderApi.Web.Core/"]
COPY ["src/OrderApi.Application/OrderApi.Application.csproj", "src/OrderApi.Application/"]
COPY ["src/OrderApi.Application.Shared/OrderApi.Application.Shared.csproj", "src/OrderApi.Application.Shared/"]
COPY ["src/OrderApi.Core.Shared/OrderApi.Core.Shared.csproj", "src/OrderApi.Core.Shared/"]
COPY ["src/OrderApi.Core/OrderApi.Core.csproj", "src/OrderApi.Core/"]
COPY ["src/OrderApi.EntityFrameworkCore/OrderApi.EntityFrameworkCore.csproj", "src/OrderApi.EntityFrameworkCore/"]
COPY ["src/OrderApi.GraphQL/OrderApi.GraphQL.csproj", "src/OrderApi.GraphQL/"]
RUN dotnet restore "src/OrderApi.Web.Public/OrderApi.Web.Public.csproj"
COPY . .
WORKDIR "/src/src/OrderApi.Web.Public"
RUN dotnet build "OrderApi.Web.Public.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderApi.Web.Public.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderApi.Web.Public.dll"]
