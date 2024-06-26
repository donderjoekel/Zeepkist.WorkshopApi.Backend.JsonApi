﻿FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
WORKDIR /src
RUN dotnet build -c Release -o /app/build

FROM build AS publish
WORKDIR /src
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false /p:UsePackageReference=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TNRD.Zeepkist.WorkshopApi.Backend.JsonApi.dll"]
