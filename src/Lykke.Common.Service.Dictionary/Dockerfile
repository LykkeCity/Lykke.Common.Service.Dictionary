FROM microsoft/aspnetcore:2.0
ENTRYPOINT ["dotnet", "Lykke.Common.Service.Dictionary.dll"]
ARG source=.
WORKDIR /app
COPY $source .