FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
WORKDIR /source
COPY . .
RUN dotnet restore
RUN dotnet publish src/Api -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 8080
COPY ./src/Infrastructure/Persistence/EntityFramework/database.sqlite .
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Api.dll"]
