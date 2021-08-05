FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
EXPOSE 80
COPY . .
RUN dotnet restore
RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -f "netcoreapp3.1" -o /app/publish
WORKDIR /app/publish
ENTRYPOINT ["dotnet", "Exemplo1.dll"]