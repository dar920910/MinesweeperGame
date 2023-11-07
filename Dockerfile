FROM mcr.microsoft.com/dotnet/sdk:7.0-jammy
WORKDIR /usr/local/src/MinesweeperGame
COPY Minesweeper.WebAPI/ Minesweeper.WebAPI/
RUN dotnet publish Minesweeper.WebAPI/Minesweeper.WebAPI.csproj --output "/usr/local/bin/MinesweeperGame/" --configuration "Release" --use-current-runtime --no-self-contained
ENV ASPNETCORE_ENVIRONMENT=Production \
    ASPNETCORE_URLS="https://+;http://+" \
    ASPNETCORE_HTTPS_PORT=5002 \
    ASPNETCORE_Kestrel__Certificates__Default__Path=/https/Minesweeper.pfx \
    ASPNETCORE_Kestrel__Certificates__Default__Password="MinesweeperGame-November_2023!"
WORKDIR /usr/local/bin/MinesweeperGame