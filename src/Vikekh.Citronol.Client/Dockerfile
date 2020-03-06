FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Vikekh.Citronol.Client/Vikekh.Citronol.Client.csproj", "src/Vikekh.Citronol.Client/"]
RUN dotnet restore "src/Vikekh.Citronol.Client/Vikekh.Citronol.Client.csproj"
COPY . .
WORKDIR "src/Vikekh.Citronol.Client"
RUN dotnet build "Vikekh.Citronol.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Vikekh.Citronol.Client.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/Vikekh.Citronol.Client/dist .
COPY ["src/Vikekh.Citronol.Client/nginx.conf", "/etc/nginx/nginx.conf"]
