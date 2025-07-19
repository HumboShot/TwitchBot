FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TwitchBot/TwitchBot.csproj", "TwitchBot/"]
RUN dotnet restore "TwitchBot/TwitchBot.csproj"
COPY . .
WORKDIR "/src/TwitchBot"
RUN dotnet build "TwitchBot.csproj" -c $BUILD_CONFIGURATION -o /app/build

ENV OAUTH_TOKEN=THISISAFAKETOKEN
ENV CHANNEL=humboshot

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TwitchBot.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TwitchBot.dll"]
