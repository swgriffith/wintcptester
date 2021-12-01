FROM mcr.microsoft.com/dotnet/framework/sdk:4.8-20200714-windowsservercore-ltsc2019 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY src .

WORKDIR /app/src
RUN msbuild /p:Configuration=Release

FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-20200714-windowsservercore-ltsc2019 AS runtime
SHELL ["powershell"]

WORKDIR /app
COPY --from=build /app/src/. ./

ENTRYPOINT powershell.exe -File c:\inetpub\wwwroot\Startup.ps1