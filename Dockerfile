# Etapa de compilação
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copia os arquivos de projeto e restaura as dependências
COPY *.sln .
COPY VerityMoney.Api/*.csproj ./VerityMoney.Api/
COPY VerityMoney.Domain/*.csproj ./VerityMoney.Domain/
COPY VerityMoney.Dto/*.csproj ./VerityMoney.Dto/
COPY VerityMoney.Infra/*.csproj ./VerityMoney.Infra/
COPY VerityMoney.Services/*.csproj ./VerityMoney.Services/
COPY VerityMoney.Specs/*.csproj ./VerityMoney.Specs/

RUN dotnet restore

# Copia e publica o aplicativo
COPY . .
WORKDIR /app/VerityMoney.Api
RUN dotnet publish -c Release -o /out

# Etapa de execução
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /out ./

# Define a porta exposta pelo contêiner
EXPOSE 80

# Executa o aplicativo quando o contêiner for iniciado
ENTRYPOINT ["dotnet", "VerityMoney.Api.dll"]
