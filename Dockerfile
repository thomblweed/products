FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app

COPY API/ /app

ENTRYPOINT ["dotnet", "run", "--urls", "http://0.0.0.0:5000"]