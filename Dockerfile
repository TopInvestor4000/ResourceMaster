FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
LABEL org.opencontainers.image.source="https://github.com/topinvestor4000/resourcemaster"
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ResourceMaster/ResourceMaster.csproj", "ResourceMaster/"]
RUN dotnet restore "ResourceMaster/ResourceMaster.csproj"
COPY . .
WORKDIR "/src/ResourceMaster"
RUN dotnet build "ResourceMaster.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ResourceMaster.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ResourceMaster.dll"]
