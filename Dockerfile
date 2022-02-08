FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app

COPY ./ ./
RUN dotnet restore

RUN dotnet publish -c Debug -o out
LABEL org.opencontainers.image.source https://github.com/OWNER/REPO

ENTRYPOINT ["dotnet", "./out/ConsultaPedidoOperacao.dll", "--urls", "http://*:80"]
