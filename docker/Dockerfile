#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
COPY /src . 
WORKDIR "/PokemonApp.Api"
RUN dotnet restore "PokemonApp.Api.csproj"
RUN dotnet build "PokemonApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PokemonApp.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:5000
ENTRYPOINT ["dotnet", "PokemonApp.Api.dll"]