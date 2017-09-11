FROM microsoft/aspnetcore:1.1.2
ENTRYPOINT ["dotnet", "Lykke.Common.Service.Dictionary.dll"]
ARG source=.
WORKDIR /app
COPY $source .