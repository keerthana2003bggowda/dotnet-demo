FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY HelloApi/HelloApi.csproj HelloApi/
RUN dotnet restore HelloApi/HelloApi.csproj
COPY HelloApi/ HelloApi/
RUN dotnet publish HelloApi/HelloApi.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
ENTRYPOINT ["dotnet", "HelloApi.dll"]