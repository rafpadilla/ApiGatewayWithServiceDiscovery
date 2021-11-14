#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ApiGatewayWithServiceDiscovery.WebApplication/ApiGatewayWithServiceDiscovery.WebApplication.csproj", "ApiGatewayWithServiceDiscovery.WebApplication/"]
COPY ["ApiGatewayWithServiceDiscovery.Common/ApiGatewayWithServiceDiscovery.Common.csproj", "ApiGatewayWithServiceDiscovery.Common/"]
RUN dotnet restore "ApiGatewayWithServiceDiscovery.WebApplication/ApiGatewayWithServiceDiscovery.WebApplication.csproj"
COPY . .
WORKDIR "/src/ApiGatewayWithServiceDiscovery.WebApplication"
RUN dotnet build "ApiGatewayWithServiceDiscovery.WebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiGatewayWithServiceDiscovery.WebApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiGatewayWithServiceDiscovery.WebApplication.dll"]