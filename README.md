# Игра "Сапёр"

Данный проект реализует веб-сервер игры "Сапёр" на базе требований спецификации OpenAPI:

:link: [Игра Сапёр (Minesweeper) | Swagger](https://minesweeper-test.studiotg.ru/swagger/#/)

Протестировать работу веб-сервера можно с помощью клиентского веб-приложения игры "Сапёр":

:link: [Сапёр (Minesweeper)](https://minesweeper-test.studiotg.ru/)

---

## Текущая Реализация

### Структура Проекта

- **Minesweeper.GameLibrary** - данный проект реализует библиотеку классов, применяемых в игре.
- **Minesweeper.GameLibrary.UnitTests** - данный проект содержит модульные тесты для библиотеки классов Minesweeper.GameLibrary.
- **Minesweeper.WebAPI** - данный проект реализует веб-службу ASP.NET Core Web API для игры "Сапёр".

---

## Повторное Использование

## Сборка, запуск и тестирование исходного кода проекта в локальной среде разработки

В локальной среде разработки вам следует использовать **.NET 7 SDK** и инструмент командной строки **dotnet**.

Построить все проекты решения:

    <username>@<hostname>:<project_work_directory>$ dotnet build

Запустить все модульные тесты:

    <username>@<hostname>:<project_work_directory>$  dotnet test

Запустить веб-сервер игры "Сапёр":

    <username>@<hostname>:<project_work_directory>$ cd ./Minesweeper.WebApi/

    <username>@<hostname>:<project_work_directory>$ dotnet run -lp https

## Сборка, запуск и тестирование исходного кода проекта в контейнере Docker

1. Создайте HTTPS-сертификат для данного проекта с помощью сценария **Create-DevCert-HTTPS**.
2. Разверните проект в контейнере Docker с помощью сценария **Execute-DockerBuild.ps1**.
3. Запустите веб-сервер в контейнере Docker с помощью сценария **Execute-DockerRun.ps1**.

---
