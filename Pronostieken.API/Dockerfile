FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Pronostieken.API/Pronostieken.API.csproj Pronostieken.API/
RUN dotnet restore Pronostieken.API/Pronostieken.API.csproj
COPY . .
WORKDIR /src/Pronostieken.API
RUN dotnet build Pronostieken.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Pronostieken.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Pronostieken.API.dll"]
