FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

ENV START_YEAR=2020
ENV END_YEAR=2022

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OechsleTest.Console.csproj", "./"]
RUN dotnet restore "OechsleTest.Console.csproj"
COPY . .

WORKDIR "/src/."
RUN dotnet build "OechsleTest.Console.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OechsleTest.Console.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OechsleTest.Console.dll"]
