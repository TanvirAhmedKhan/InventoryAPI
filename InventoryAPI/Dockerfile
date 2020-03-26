FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ["InventoryAPI.csproj", "./"]
RUN dotnet restore "./InventoryAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "InventoryAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InventoryAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InventoryAPI.dll"]
