#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ApiGatewayWithServiceDiscovery.ApiGateway/ApiGatewayWithServiceDiscovery.ApiGateway.csproj", "ApiGatewayWithServiceDiscovery.ApiGateway/"]
RUN dotnet restore "ApiGatewayWithServiceDiscovery.ApiGateway/ApiGatewayWithServiceDiscovery.ApiGateway.csproj"
COPY . .
WORKDIR "/src/ApiGatewayWithServiceDiscovery.ApiGateway"
RUN dotnet build "ApiGatewayWithServiceDiscovery.ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiGatewayWithServiceDiscovery.ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiGatewayWithServiceDiscovery.ApiGateway.dll"]