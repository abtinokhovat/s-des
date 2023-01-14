FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["s-des-api/s-des-api.csproj", "s-des-api/"]
RUN dotnet restore "s-des-api/s-des-api.csproj"
COPY . .
WORKDIR "/src/s-des-api"
RUN dotnet build "s-des-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "s-des-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "s-des-api.dll"]
