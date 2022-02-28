#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS build
WORKDIR /Minimal.Api
COPY ["Minimal.Api.csproj", "Minimal.Api/"]
RUN dotnet restore "Minimal.Api/Minimal.Api.csproj"
COPY . .
WORKDIR "/Minimal.Api"
RUN dotnet build "Minimal.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Minimal.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
COPY bin/Release/net6.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "Minimal.Api.dll"]