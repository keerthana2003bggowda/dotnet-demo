FROM mcr.microsoft.com/dotnet/sdk:10.0
WORKDIR /app
COPY . .
RUN dotnet build -c Release -o out
EXPOSE 8080
CMD ["dotnet", "out/HelloApi.dll"]