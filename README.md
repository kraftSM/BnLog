
# BnLog
Начальная версия  итогового проекта C# of SkillFactory. (V0.0.1 2023-11-01)
 - BnLog = это и Blog и Log и etc...
 - Разбиения на подпроекты не будет, структурируем папками

## Планируемая структура проекта
 - BnLog = основной проект
 - - += запускаемая часть основного проекта
 - Docs = Описание проекта и его элеметов
 - Repo = Data Layer
   - -  = BD, Data model, Repository
   - -  = Здесь ( и ниже) место компонетов, обеспечивающих доступ к хранилищам данных
 - Views = View Model Layer
   - -  = Layer for Data buinding model, Repository <> Site
-  Controllers =  Buisnes Controller Layer
   - -  = Buisnes Rule Layer
   - -  =  Site page Controllers   
 - wwwroot = корневая папка сайта (auto)
   - -  = стили, ресурсы
   - -  = страничные представления(?)

