# Multi-stage Docker build for ASP.NET Core 8
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["ProductCatalog.csproj", "./"]
RUN dotnet restore "ProductCatalog.csproj"

COPY . .
RUN dotnet publish "ProductCatalog.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_HTTP_PORTS=10000
EXPOSE 10000
ENTRYPOINT ["dotnet", "ProductCatalog.dll"]
