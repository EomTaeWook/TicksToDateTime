FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

COPY WebApp ./WebApp
COPY DataContainer ./DataContainer
COPY Dll ./Dll

RUN dotnet restore "WebApp/WebApp.csproj"
RUN dotnet publish "WebApp/WebApp.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App

COPY --from=build-env /App/out ./WebApp

VOLUME ["/App/log"]

VOLUME ["/App/archive"]

VOLUME ["/App/cdn"]

WORKDIR /App/WebApp

ENTRYPOINT ["dotnet", "WebApp.dll"]