FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

EXPOSE 5000

COPY /bin/Release /app/Release
WORKDIR /app/Release
ENTRYPOINT dotnet AvionicsCloud.UI.dll