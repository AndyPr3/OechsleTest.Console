#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OechsleTest.Console/OechsleTest.Console.csproj", "OechsleTest.Console/"]
RUN dotnet restore "OechsleTest.Console/OechsleTest.Console.csproj"
COPY . .
ENV START_YEAR 2020
ENV END_YEAR 2022
WORKDIR "/src/OechsleTest.Console"
RUN dotnet build "OechsleTest.Console.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OechsleTest.Console.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OechsleTest.Console.dll"]