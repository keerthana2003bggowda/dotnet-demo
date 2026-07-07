FROM mcr.microsoft.com/dotnet/sdk:10.0
WORKDIR /app
COPY . .
RUN dotnet build HelloApi/HelloApi.csproj -c Release -o out
EXPOSE 8081
CMD ["dotnet", "out/HelloApi.dll"]