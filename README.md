
# BnLog
Начальная версия итогового проекта C# of SkillFactory.
 - BnLog = это и Blog и Log и etc...
 - Разбиения на подпроекты не будет, структурируем папками

## Планируемая структура проекта
 - BnLog = основной проект
  -  = запускаемая часть основного проекта-
 --+ Docs = Описание проетаи его элеметов
 --+ wwwroot = корневая папка сайта (auto)
      -  + стили, ресурсы
         + страничные представления
 -+ Repo = Data Layer
   -  = BD, Data model, Repository
 -+ Views = View Model Layer
 -    -  = Layer for Data buinding model, Repository <> Site
--+ Controllers =  Buisnes Controller Layer
 --  = Buisnes Rule Layer
 --  = Site page Controllers
