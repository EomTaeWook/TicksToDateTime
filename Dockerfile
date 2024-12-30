FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

COPY WebApp ./WebApp
COPY DataContainer ./DataContainer
COPY Dll ./Dll
COPY Protocols ./Protocols

RUN dotnet restore "WebApp/WebApp.csproj"
RUN dotnet publish "WebApp/WebApp.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App

COPY --from=build-env /App/out ./WebApp

VOLUME ["/App/WebApp/log"]

VOLUME ["/App/WebApp/archive"]

VOLUME ["/App/Datas"]

WORKDIR /App/WebApp

ENTRYPOINT ["dotnet", "WebApp.dll"]