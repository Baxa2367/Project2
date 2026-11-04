
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

RUN apt-get update && apt-get install -y unzip

COPY ProductCatalog_Render_Ready.zip /tmp/project.zip
RUN unzip /tmp/project.zip -d /src

WORKDIR /src/ProductCatalog
RUN dotnet publish ProductCatalog.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "ProductCatalog.dll"]
