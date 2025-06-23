# Stage de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia os arquivos do projeto
COPY *.sln . 
COPY . . 

# Restaura dependências
RUN dotnet restore

# Builda o projeto
RUN dotnet publish -c Release -o /app/publish

# Stage final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copia os arquivos da stage de build
COPY --from=build /app/publish .

# Expõe as portas
EXPOSE 7001
EXPOSE 5000

# Comando pra rodar a API
ENTRYPOINT ["dotnet", "MothAphotheaShopAPI.dll"]
