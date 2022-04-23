FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Sharp.Shop.Api/Sharp.Shop.Api.csproj", "Sharp.Shop.Api/"]
RUN dotnet restore "Sharp.Shop.Api/Sharp.Shop.Api.csproj"
COPY . .
WORKDIR "/src/Sharp.Shop.Api"
RUN dotnet build "Sharp.Shop.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sharp.Shop.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sharp.Shop.Api.dll"]
