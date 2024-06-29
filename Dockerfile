# Use the SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /lir-backend

EXPOSE 8080
EXPOSE 8081

COPY . .

RUN dotnet restore ./src/Lir.Api/Lir.Api.csproj

RUN dotnet build ./src/Lir.Api/Lir.Api.csproj -c Release

RUN dotnet publish ./src/Lir.Api/Lir.Api.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build-env /lir-backend/out .

ENTRYPOINT ["dotnet", "Lir.Api.dll"]
