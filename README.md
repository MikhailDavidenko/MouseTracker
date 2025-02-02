# MouseTracker

Проект MouseTracker представляет собой приложение для отслеживания движения мыши. 

## WEB

В качестве веб-приложения используется ASP.NET Core MVC для упрощения тестирования приложения.
Если же есть необходимость протестировать фронтенд и бэкенд по отдельности, то можно открыть файл `frontend/index.html`,
в котором содержится тот же HTML и JS код.

Есть главная страница приложения, на которой отслеживается движение мыши.
После нажатия на кнопку отправляется запрос на сервер, и в консоли выводится сообщение о том, прошел ли запрос успешно.

Для обработки и сохранения данных о координатах мыши используется REST API контроллер.

## База данных

В примере используется SqlServer. Для корректной работы необходимо в файле конфигурации добавить строку подключения к базе данных. 
Для примера добавил возможную строку подключения.

## Миграции

При каждом запуске будет выполняться миграция недостающих изменений в бд.

Для создания миграции используется команда(из корневой директории)
``` bash
cd .\src | dotnet ef migrations add Init --startup-project Web --context MouseTracker.Data.Engine.AppDbContext --project Data
```

Для применения миграции вручную используется команда(из корневой директории)
``` bash
cd .\src\Web | dotnet ef database update
```

## Запуск приложения

Для запуска приложения из корневой директории проекта используется команда
```shell
dotnet run --project .\src\Web
```

## Тесты

Для запуска тестов из корневой директории проекта:
```shell
dotnet test
```