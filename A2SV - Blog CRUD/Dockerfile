FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["A2SV - Blog CRUD/A2SV - Blog CRUD.csproj", "A2SV - Blog CRUD/"]
RUN dotnet restore "A2SV - Blog CRUD/A2SV - Blog CRUD.csproj"
COPY . .
WORKDIR "/src/A2SV - Blog CRUD"
RUN dotnet build "A2SV - Blog CRUD.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "A2SV - Blog CRUD.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "A2SV - Blog CRUD.dll"]
