FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 57569
EXPOSE 44398

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Pronostieken/Pronostieken.csproj Pronostieken/
RUN dotnet restore Pronostieken/Pronostieken.csproj
COPY . .
WORKDIR /src/Pronostieken
RUN dotnet build Pronostieken.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Pronostieken.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Pronostieken.dll"]
