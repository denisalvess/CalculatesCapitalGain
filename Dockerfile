#Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

ADD ../rsc/UnitTest/data/ /app/data

#Copiar os arquivos do projeto
COPY . .
RUN dotnet restore
RUN dotnet build --no-restore
RUN dotnet test --no-build
RUN dotnet publish -c Release -o /app/publish

#Etapa de runtime
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
COPY --from=build /app/data ./data

#Comando para iniciar a aplicação
ENTRYPOINT ["dotnet","CalculatesCapitalGain.dll" ]