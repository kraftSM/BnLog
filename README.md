
# BnLog
## Рабочая версия  итогового проекта C# of SkillFactory.(V1.x.x от 2023-11-21)
  - - Реализация  требований HW3 (HW3 route)
  - - + Добавление в проект Валидации
  - - -  Фактически Валидация планируется с использованием пакета FluentValidation
  - - + Добавление в проект NLog
  - - -  Фактически логгирование идет в Bin директроию ...\BnLog\bin\Debug\net6.0\logs\...
  - - -  для проверки функционирвания внесены  измения в Nlog.config для логгирования в файлы (LogPart.log,Error.log), находящиеся в ...\BnLog\\logs\...
  - - - + variable name="logDirectory" value="C:\Users\sergey\source\repos\BnLog\logs"/>
  - - - + target xsi:type="File" name="filePart" fileName="${logDirectory}/LogPart.log" layout="${longdate} ${uppercase:${level}} ${message}" />
  - - - + target xsi:type="File" name="fileErr" fileName="${logDirectory}/Error.log" layout="${longdate} ${uppercase:${level}} ${message}" />
  - - - + logger name="*" minlevel="Debug" writeTo="filedata" 
  - - - + logger name="*" minlevel="Info" writeTo="filePart" 
  - - - + logger name="*" minlevel="Error" writeTo="fileErr" 
  - - - - что оказалось работоспособным (в LogPart.log только Info, в Error.log только Info, в 1-м файле полный LOG)
  - - + Добавлена кодификация ошибок ()
  - -  Анализ Логов ошибки показал наличие необработанных. Добавление в проект Глобального обработчика (MidleWare + мелочей для него) не получлось...
  - - -  При наследовании ExceptionMiddleware : IMiddleware требует сервис, которого не находит
  - - -  При Не наследовании ExceptionMiddleware //: IMiddleware не видет ошибку в цепочке обработки

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
  - - -  сделан редирект в Program.cs и заготовки на обработчик ошибок/исключений но глобально все допилится в HW3(там есть такой пункт)
  - - Реализованые основные архитектурные опции  
  - - + Сделан уровень данных и репозитрии для Items, ItemOption,ItemOption, ItemResurce
  - - + Сделан в BnLog.BLL.Extentions уголок для Extentions, и там сгруппировано add-ins для сервисови UoW (not work now-> exeption in IoC)
  - - + Сделан  для работы с ними service (частично, скорее как заготовка) и контролер (под Дизайнер/Администратор)
  - - + Сделан  в VAL перенос service'ов ViewDataModels (частично, их разбивка на Request/Response)
  - - -Не получилось сделать UoW сегменте [Items, ItemOption,ItemOption, ItemResurce] - после нескольких заходов пришлось делать явно :(
## Версия  итогового проекта C# of SkillFactory.(V1.0.2 от 2023-11-09)
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

