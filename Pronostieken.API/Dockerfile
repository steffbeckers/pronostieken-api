FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Pronostieken.API/Pronostieken.csproj Pronostieken/
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
