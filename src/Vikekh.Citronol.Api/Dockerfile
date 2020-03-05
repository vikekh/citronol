#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Vikekh.Citronol.Api/Vikekh.Citronol.Api.csproj", "src/Vikekh.Citronol.Api/"]
RUN dotnet restore "src/Vikekh.Citronol.Api/Vikekh.Citronol.Api.csproj"
COPY . .
WORKDIR "/src/src/Vikekh.Citronol.Api"
RUN dotnet build "Vikekh.Citronol.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Vikekh.Citronol.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Vikekh.Citronol.Api.dll"]