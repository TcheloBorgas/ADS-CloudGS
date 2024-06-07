# Usar a imagem do SDK do .NET para compilar o projeto no estágio de construção
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /src

# Copiar csproj e restaurar as dependências
COPY app/SeaGo.csproj ./app/
RUN dotnet restore app/SeaGo.csproj

# Copiar os arquivos do projeto
COPY app/ ./app/

# Compilar e publicar o projeto
RUN dotnet publish app/SeaGo.csproj -c Release -o /app/out --no-restore

# Usar a imagem de runtime do .NET para a imagem final
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

# Criar um usuário não-privilegiado
RUN groupadd -r nonroot && useradd -r -g nonroot -d /app -s /sbin/nologin nonroot && chown -R nonroot:nonroot /app
USER nonroot

# Copiar os artefatos do build para o diretório de trabalho
COPY --from=build-env /app/out ./

# Definir variáveis de ambiente (ajuste conforme necessário)
ENV ASPNETCORE_ENVIRONMENT=Production
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
ENV ASPNETCORE_URLS=http://+:80

# Expor a porta 80
EXPOSE 80

# Definir o ponto de entrada para o contêiner
ENTRYPOINT ["dotnet", "SeaGo.dll"]
