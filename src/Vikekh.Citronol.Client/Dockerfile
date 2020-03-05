FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS build
WORKDIR /src
COPY ["src/Vikekh.Citronol.Client/Vikekh.Citronol.Client.csproj", "src/Vikekh.Citronol.Client/"]
RUN dotnet restore "src/Vikekh.Citronol.Client/Vikekh.Citronol.Client.csproj"
COPY . .
WORKDIR "src/src/Vikekh.Citronol.Client"
RUN dotnet build "Vikekh.Citronol.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Vikekh.Citronol.Client.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/BlazorWasmDocker/dist .
COPY nginx.conf /etc/nginx/nginx.conf
