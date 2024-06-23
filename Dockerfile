FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /lir-backend
EXPOSE 8080
EXPOSE 8081

COPY . ./src
RUN ls ./src
RUN ls ./src

WORKDIR /lir-backend/src
RUN dotnet build
RUN dotnet restore

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /lir-backend/src/Lir.Api
COPY --from=build-env /lir-backend/src/out .
ENTRYPOINT ["dotnet", "Lir.Api.dll"]