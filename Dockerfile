FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CustomerPurchaseRecord.API/CustomerPurchaseRecord.API.csproj", "CustomerPurchaseRecord.API/"]
COPY ["CustomerPurchaseRecord.DataService/CustomerPurchaseRecord.DataService.csproj", "CustomerPurchaseRecord.DataService/"]
COPY ["CustomerPurchaseRecord.Entities/CustomerPurchaseRecord.Entities.csproj", "CustomerPurchaseRecord.Entities/"]
RUN dotnet restore "CustomerPurchaseRecord.API/CustomerPurchaseRecord.API.csproj"
COPY . .
WORKDIR "/src/CustomerPurchaseRecord.API"
RUN dotnet build "CustomerPurchaseRecord.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CustomerPurchaseRecord.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final 
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "CustomerPurchaseRecord.API.dll" ]