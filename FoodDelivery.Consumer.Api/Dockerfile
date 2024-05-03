FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FoodDelivery.Consumer.Api/FoodDelivery.Consumer.Api.csproj", "FoodDelivery.Consumer.Api/"]
RUN dotnet restore "FoodDelivery.Consumer.Api/FoodDelivery.Consumer.Api.csproj"
COPY . .
WORKDIR "/src/FoodDelivery.Consumer.Api"
RUN dotnet build "FoodDelivery.Consumer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FoodDelivery.Consumer.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FoodDelivery.Consumer.Api.dll"]
