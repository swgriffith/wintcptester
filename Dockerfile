FROM mcr.microsoft.com/windows/servercore:ltsc2019

WORKDIR /apps

# copy csproj and restore as distinct layers
COPY ./dotnettcp/binaries/dotnettcp.exe .
COPY ./dotnettcp-sender/binaries/dotnettcp-sender.exe .

COPY ./winsock/binaries/Client.exe .
COPY ./winsock/binaries/Server.exe .

ENTRYPOINT powershell.exe 