#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/azure-functions/dotnet:4 AS base
WORKDIR /home/site/wwwroot
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Notification/Notification.Function/Notification.Function.csproj", "Services/Notification/Notification.Function/"]
RUN dotnet restore "Services/Notification/Notification.Function/Notification.Function.csproj"
COPY . .
WORKDIR "/src/Services/Notification/Notification.Function"
RUN dotnet build "Notification.Function.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Notification.Function.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /home/site/wwwroot
COPY --from=publish /app/publish .
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true