# MouseTracker

## База данных

В примере используется SqlServer. Для корректной работы необходимо в файле конфигурации добавить строку подключения к базе данных. 
Для примера добавил возможную строку подключения.

## Миграции

При каждом запуске будет выполняться миграция недостающих изменений в бд.

Для создания миграции используется команда
``` bash
cd src | dotnet ef migrations add Init --startup-project Web --context MouseTracker.Data.Engine.AppDbContext --project Data
```

Для применения ручной миграции используется команда
``` bash
cd Web | dotnet ef database update
```