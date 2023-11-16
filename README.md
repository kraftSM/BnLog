
# BnLog
## Текущая версия  итогового проекта C# of SkillFactory.(V1.2.2 от 2023-11-16)
 - Версия подготовленная для сдачи 2- этапа Д/З ()  in :HW2 (c master не сливалось)
  - - Реализованы основные требования HW2  
  - - + Вёрстка основного макета Layout
  - - -  Сверстать меню -> Link's to активные элементы сайта (с учетом прав доступа = роли)
  - - -  Сверстать футер -> Версия сайта (пока как текст) + Link's to страницу безопасности
  - - + Разработка представлений (в основном, ИМХО. Возможно что-то просмотрел...)
  - - - Добавить представление для просмотра, редактирования, добавления и удаления
  - - - пользователя, роли пользователя, статьи, комментария
  - - - Добавить представление для просмотра всех пользователей, их ролей,статей, комментариев
  - - - + В представление для просмотра всех пользователей через [ViewBag.CardView...ViewBag.TableView...] параметрически выбирается способ отображеня.
  - - - + Динамичность будет позже, через ItemInfo ...
  - - + Добавление системных страниц с ошибками
  - - -  В [Route("Home/Error")] дописан обработчик = сверстаны макеты страниц, но total'но не прверялось
  - - -  сделаны редирект в Program.cs b заготовки на обработчик ошибок/исключений но глобально все допилится в HW3(там есть такой пункт)
  - - Реализованые основные архитектурные опции  
  - - + Сделан уровень данных и репозитрии для Items, ItemOption,ItemOption, ItemResurce
  - - + Сделан  для работы с ними service (частично, скорее как заготовка) и контролер (под Дизайнер/Администратор)
  - - + Сделан  в VAL перенос service'ов ViewDataModels (частично, их разбивка на Request/Response)
  - - -Не получилось сделать UoW сегменте [Items, ItemOption,ItemOption, ItemResurce] - после нескольких заходов пришлось делать явно :(
## Dерсия  итогового проекта C# of SkillFactory.(V1.0.2 от 2023-11-09)
 - Версия подготовленная для сдачи 1- этапа Д/З ()
  - - Основные требования HW1 реализованы (в основном, ИМХО. Возможно что-то просмотрел...)
  - - Под остальные особенности/мечты сделанызаделы.Реализация частичная. Будет "добиваться" по-ходу
  - - Захвачен кусок 2 этапа (по Видам, но доделывать не стремился. Виды сдам позже) без которого не так хорошо отлаживать Appl
 - ---------------------------------------------------
   - - [Начальная версия  итогового проекта C# of SkillFactory. (V0.0.1 2023-11-01)]
   - - - Здесь были наброски всего по чуть-чуть 
## О проекте...
- BnLog = это и Blog и Log и etc... (похоже это ...etc как раз и не будет сделано)
 - Разбиения на подпроекты не будет, структурируем папками
## Структура проекта == На 2023-11-09 [точно еще будет пересмотрена ! :( ]
 - BnLog = основной проект
 - - += запускаемая часть основного проекта
 - Docs = Описание проекта и его элеметов
 - DAL = Data Aplication Layer
   - -  = BD, Data model, Repository
   - -  = Здесь ( и ниже) место компонетов, обеспечивающих доступ к хранилищам данных
- VAL = View Aplication Layer (View Model Layer)
   - -  = Layer for Data buinding model, Repository <> Site
 - Views = View Model Layer
   - -  = Site Views
- VAL = Buisnes Aplication Rule Layer
   - -  =  Buisnes Rule 
   - -  =  Site page Controllers
   - -  =  Aplication Services (тоже пока здесь)     
 - wwwroot = корневая папка сайта (auto)
   - -  = стили, ресурсы
   - -  = страничные представления(?)
 
## Планируемая структура проекта == На 2023-11-09 пересмотрена
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

