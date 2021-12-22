﻿# is-oop-y24/Ar4eR-ValerA

[![wakatime](https://wakatime.com/badge/user/6f9f48c5-e4ed-4eb0-b0b7-caf743286d27.svg)](https://wakatime.com/@6f9f48c5-e4ed-4eb0-b0b7-caf743286d27)
# [Лабораторная 0. Isu](Isu)

**Цель:** ознакомиться с языком C#, базовыми механизмами ООП. В шаблонном репозитории описаны базовые сущности, требуется реализовать недостающие методы и написать тесты, которые бы проверили корректность работы.

**Предметная область. С**туденты, группы, переводы (хоть где-то), поиск. Группа имеет название (соответсвует шаблону M3XYY, где X - номер курса, а YY - номер группы). Студент может находиться только в одной группе. Система должна поддерживать механизм перевода между группами, добавления в группу и удаление из группы.

Требуется реализовать предоставленный в шаблоне интерфейс:

```csharp
public interface IIsuService
{
    Group AddGroup(GroupName name);
    Student AddStudent(Group group, string name);

    Student GetStudent(int id);
    Student FindStudent(string name);
    List<Student> FindStudents(GroupName groupName);
    List<Student> FindStudents(CourseNumber courseNumber);

    Group FindGroup(GroupName groupName);
    List<Group> FindGroups(CourseNumber courseNumber);

    void ChangeStudentGroup(Student student, Group newGroup);
}
```

И протестировать написанный код:

```csharp
[Test]
public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
{
}

[Test]
public void ReachMaxStudentPerGroup_ThrowException()
{
}

[Test]
public void CreateGroupWithInvalidName_ThrowException()
{
}

[Test]
public void TransferStudentToAnotherGroup_GroupChanged()
{
}
```

# [Лабораторная 1. Shops](Shops)

**Цель:** продемонстрировать умение выделять сущности и проектировать по ним классы.

**Прикладная область**: магазин, покупатель, доставка, пополнение и покупка товаров. Магазин имеет уникальный идентификатор, название (не обязательно уникальное) и адрес. В каждом магазине установлена своя цена на товар и есть в наличии некоторое количество единиц товара (какого-то товара может и не быть вовсе). Покупатель может производить покупку. Во время покупки - он передает нужную сумму денег магазину. Поставка товаров представляет собой набор товаров, их цен и количества, которые должны быть добавлены в магазин.

Тест кейсы:

1. Поставка товаров в магазин. Создаётся магазин, добавляются в систему товары, происходит поставка товаров в магазин. После добавления товары можно купить.
2. Установка и изменение цен на какой-то товар в магазине.
3. Поиск магазина, в котором партию товаров можно купить максимально дешево. Обработать ситуации, когда товара может быть недостаточно или товаров может небыть нигде.
4. Покупка партии товаров в магазине (набор пар товар + количество). Нужно убедиться, что товаров хватает, что у пользователя достаточно денег. После покупки должны передаваться деньги, а количество товаров измениться.

NB:

- Можно не поддерживать разные цены для одного магазина. Как вариант, можно брать старую цену, если магазин уже содержит этот товар. Иначе брать цену указанную в поставке.
- Пример ожидаемого формата тестов представлен ниже. **Используемые в тестах API магазина/менеджера/etc не являются интерфейсом для реализации в данной лабораторной. Не нужно ему следовать 1 в 1, это просто пример.**

```csharp
public void SomeTest(moneyBefore, productPrice, productCount, productToBuyCount)
{
	var person = new Person("name", moneyBefore);
	var shopManager = new ShopManager();
	var shop = shopManager.Create("shop name", ...);
	var product = shopManager.RegisterProduct("product name");
	
	shop.AddProducts( ... );
	shop.Buy(person, ...);
	
	Assert.AreEquals(moneyBefore - productPrice  * productToBuyCount, person.Money);
	Assert.AreEquals(productCount - productToBuyCount , shop.GetProductInfo(product).Count);
}
```

# [Лабораторная 2. ISUExtra (<3 ОГНП)](IsuExtra)

**Цель:**  научиться выделять зоны ответственности разных сущностей и проектировать связи между ними.

**Предметнвая область:** Реализация системы записи студентов на ОГНП.

Курс ОГНП - дополнительные занятия, которые могут изучать студенты. Курс реализует определенный мегафакультет. Курс изучается в несколько потоков с ограниченным количеством мест. У каждого потока есть свое расписание - список пар, которые проводятся в течение недели. Пара - описание временного интервала в который группа занимается. Пара должна быть ассоциирована с группой, временем, преподавателем и аудиторией.

Студенты могут записываться на два разных курса ОГНП. Студент не может записаться на ОГНП, которое представляет мегафакультет его учебной группы. Учебная группы принадлежат определенному мегафакультету, который определятся из названия группы. Каждый учебная группа имеет список пар. При записи студента должна быть проверка на то, что пары его учебной группы не пересекаются с парами потока ОГНП.

Требуется реализовать функционал:

- Добавление нового ОГНП
- Запись студента на опредленный ОГНП
- Возможность снять запись
- Получение потоков по курсу
- Получение списка студентов в определенной группе ОГНП
- Получение списка не записавшихся на курсы студентов по группе

# [Лабораторная 3. Backups](Backups)
**[TCP Backups Client](Backups.Client)**

**[TCP Backups Server](Backups.Server)**

**Цель:** применить на практике принципы из SOLID, GRASP.

## **Предметная** область

**Бекап (Backup)** — в общем случае, это резервная копия каких-то данных, которая делается для того, чтобы в дальнейшем можно было восстановить эти данные, то есть откатиться до того момента, когда она была создана. В контексте данной системы, бекапом обозначим связанную цепочку созданных точек.

**Точка восстановления (Restore point)** — резервная копия объектов, созданная в определенный момент. Описать можно датой создания и список резервных копий объектов, которые бекапились в момент создания точки.

**Бекапная джоба (Backup job)** - сущность, которая содержит информацию о конфигурации создаваемых бекапов (список файлов, которые нужно бекапить, способ хранения и прочее) и о уже созданных точках данного бекапа. Также отвечает за создание новых точек восстановления.

**Объект джобы (Job object)** - объекты, которые добавлены с бекапную джобу, для которых нужно создавать копии при процессинге джобы.

**Сторадж (Storage)** - файл, в котором хранится резервная копия объекта джобы, который был создан в конкретной точке.

**Репозиторий (Repository)** - абстракция над способом хранения бекапов. В рамках самого простого кейса, репозиторием будет некоторая директория на локальной файловой системе, где будут лежать стораджи.

## Пример логики работы

Выполняем такие действия:

- Создаём джобу, добавляем три объекта FileA FileB FileC
- Запускаем джобу, получаем рестор поинт в котором есть стораджи FileA_1 FileB_1 FileC_1
- Повторяем, получаем стораджи *_2
- Убираем из бекапной джобы FileC, запускаем джобу, получаем третий рестор поинт у которого есть два стораджа - FileA_3 FileB_3

## Создание резервных копий

Под созданием резервной копии файла подразумевается создание копии файла в другом месте. Система должна поддерживать расширяемость в алгоритмах создания резервных копий. Требуется реализовать два алгоритма:

1. Алгоритм раздельного хранения (Split storages) — для каждого объекта, который добавлен в джобу, создается копия - zip файл, в котором лежит объект.
2. Алгоритм общего хранения (Single storage) —  все указанные в бекапе объекты сохраняются в один архив.

## Хранение копий

В лабораторной работе подразуемвается, что резервные копии будут создаваться локально на файловой системе. Но логика выполнения должна абстрагироваться от этого, должна быть введена абстракция - репозиторий (см. принцип DIP из SOLID). И, например, в тестах стоит реализовать хранение в памяти, иначе тесты будут создавать много мусора, будут требовать дополнительной конфигурации, а также могут начать внезапно падать. Ожидаемая структура:

- Корневая директория
    - Директории джоб, которые лежат в корневой директории
        - Файлы резервных копий, которые лежат в директории джобы

## Создание рестор поинтов

За создание новой точки восстановления отвечает джоба. При создании джобы указывается ее название, способ хранения. Джоба может быть отредактирована за счет добавления или удаления. Результатом работы алгоритма является создание новой точки восстановления. Точка восстановления хранит о себе информацию о том, какие объекты были в ней забекаплены.

## Тест кейсы

1. Тест-1
    1. Cоздаю бекапную джобу
    2. Указываю Split storages
    3. Добавляю в джобу два файла
    4. Запускаю создание точки
    5. Удаляю один из файлов
    6. Запускаю создание
    7. Проверяю, что создано две точки и три стораджа
2. Тест-2, который лучше оформлять не тестом т.к. посмотреть нормально можно только на настоящей файловой системе
    1. Cоздаю бекапную джобу, указываю путь директории для хранения бекапов
    2. Указываю Single storage
    3. Добавляю в джобу два файла
    4. Запускаю создание точки
    5. Проверяю, что созданы директории и файлы

# [Лабораторная 4. Banks](Banks)
## Дополнительно - ORM

**Цель:** применить на практике принципы из SOLID, GRASP, паттерны

## Предметная область

Есть несколько **Банков**, которые предоставляют финансовые услуги по операциям с деньгами.

В банке есть **Счета** и **Клиенты**. У клиента есть имя, фамилия, адрес и номер паспорта (имя и фамилия обязательны, остальное – опционально).

## Счета и проценты

Счета бывают трёх видов: **Дебетовый счет**, **Депозит** и **Кредитный счет**. Каждый счет принадлежит какому-то клиенту.

**Дебетовый счет** – обычный счет с фиксированным процентом на остаток. Деньги можно снимать в любой момент, в минус уходить нельзя. Комиссий нет.

**Депозитный счет** – счет, с которого нельзя снимать и переводить деньги до тех пор, пока не закончится его срок (пополнять можно). Процент на остаток зависит от изначальной суммы, **например**, если открываем депозит до 50 000 р. - 3%, если от 50 000 р. до 100 000 р. - 3.5%, больше 100 000 р. - 4%. Комиссий нет. Проценты должны задаваться для каждого банка свои.

**Кредитный счет** – имеет кредитный лимит, в рамках которого можно уходить в минус (в плюс тоже можно). Процента на остаток нет. Есть фиксированная комиссия за использование, если клиент в минусе.

## Комиссии

Периодически банки проводят операции по выплате процентов и вычету комиссии. Это значит, что нужен механизм проматывания времени, чтобы посмотреть, что будет через день/месяц/год и т.п.

Процент на остаток начисляется ежедневно от текущей суммы в этот день, но выплачивается раз в месяц (и для дебетовой карты и для депозита). Например, 3.65% годовых. Значит в день: 3.65% / 365 дней = 0.01%. У клиента сегодня 100 000 р. на счету - запомнили, что у него уже 10 р. Завтра ему пришла ЗП и стало 200 000 р. За этот день ему добавили ещё 20 р. На следующий день он купил себе новый ПК и у него осталось 50 000 р. - добавили 5 р. Таким образом, к концу месяца складываем все, что запоминали. Допустим, вышло 300 р. - эта сумма добаляется к счету или депозиту в текущем месяце.

Разные банки предлагают разные условия. В каждом банке известны величины процентов и комиссий.

## Центральный банк

Регистрацией всех банков, а также взаимодействием между банками занимается центральный банк. Он должен предоставлять все нужные другим банкам методы, методы добавления нового банка. Он также занимается уведомлением других банков о том, что нужно начислять остаток или комиссию - для этого механизма не требуется создавать таймеры и завязываться на реальное время.

## Операции и транзакции

Каждый счет должен предоставлять механизм **снятия**, **пополнения** и **перевода** денег (то есть счетам нужны некоторые идентификаторы).

Еще обязательный механизм, который должны иметь банки - **отмена транзакций**. Если вдруг выяснится, что транзакция была совершена злоумышленником, то такая транзакция должна быть отменена. Отмена транзакции подразумевает возвращение суммы обратно. Транзакция не может быть повторно отменена.

## Создание клиента и счета

Клиент должен создаваться по шагам. Сначала он указывает имя и фамилию (обязательно), затем адрес (можно пропустить и не указывать), затем паспортные данные (можно пропустить и не указывать).

Если при создании счета у клиента не указаны адрес или номер паспорта, мы объявляем такой счет (любого типа) сомнительным, и запрещаем операции снятия и перевода выше определенной суммы (у каждого банка своё значение). Если в дальнейшем клиент указывает всю необходимую информацию о себе - счет перестает быть сомнительным и может использоваться без ограничений.

## Обновление условий счетов

Для банков требуется реализовать методы изменений процентов и лимитов не перевод. Также требуется реализовать возможность пользователям подписываться на информацию о таких изменениях - банк должен предоставлять интерфейс для подписывания. Например, когда происходит изменение лимита для кредитных карт - все пользователи, которые подписались и имеют кредитные карты, должны получить уведомление.

## Консольный интерфейс работы

Для взаимодействия с банком требуется реализовать консольный интерфейс, который будет взаимодействовать с логикой приложения, отправлять и получать данные, отображать нужную информацию и предоставлять интерфейс для ввода информации пользователем.

# Лабораторная 5. BackupsExtra

## Теормин

Слиянияе точек восстановления (мердж) - процесс слияния двух точек в результате которого получается одна точка

## Сохранение и загрузка данных

Система должна уметь загружать свое состояние после перезапуска программы. Это может быть реализовано за счет сохранения данных о настройках джоб в конфигурационный файл, который будет лежать в корневой директории. После загрузки ожидается, что в приложение загрузится информация о существующих джобах, добавленных в них объектах, информация о созданных точках восстановления.

## Алгоритмы очистки точек

Помимо создания, нужно контролировать количество хранимых точек восстановления. Чтобы не допускать накопления большого количества старых и неактуальных точек, требуется реализовать механизмы их очистки — они должны контролировать, чтобы цепочка точек восстановления не выходила за допустимый лимит. В рамках лабораторной ожидается реализация таких типов лимитов:

1. По количеству рестор поинтов - ограничивает длину цепочки из рестор поинтов (храним последние N рестор поинтов и очищаем остальные)
2. По дате - ограничивает насколько старые точки будут хранится (очищаем все точки, которые были сделаны до указанной даты)
3. Гибрид - возможность комбинировать лимиты. Пользователь может указывать, как комбинировать:
   - нужно удалить точку, если она не подходит хотя бы под один установленный лимит
   - нужно удалить точку, если она не подходит за все установленные лимиты

Например, пользователь выбирает гибрид алгоритмов "по количеству" и "по дате". Если по одному из алгоритмов необходимо оставить точки P1 P2 P3, а по другому — P1 P2 P3 P4 P5, то в первом варианте останутся точки P1-P3, а во втором - P1-P5.

Если для соответствия лимита требуется удалить все точки - должна бросаться ошибка.

## Мердж точек

Стоит разделять алгоритм выбора точек для удаления и процесс удаления. Требуется поддержать альтернативное поведение при выходе за лимиты - мердж точек. Мердж работает по правилам:

- Если в старой точке есть объект и в новой точке есть объект - нужно оставить новый, а старый можно удалять
- Если в старой точке есть объект, а в новоей его нет - нужно перенести его в новую точку
- Если в точке объекты храняться по правилу Single storage, то старая точка просто удаляется

## Логирование

Логика работы бекпов не должна напрямую завязываться на консоль или другие внешние компоненты. Чтобы поддержать возможность уведомлять пользователя о событиях внутри алгоритма, требуется реализовать интерфейс для логирования и вызывать его в нужных моментах. Например, писать что создается сторадж или рестор поинт. Задаваться способ логирования должен из-вне. Например, при создании джобы. В рамках системы ожидаются такие реализации логера:

- Консольный, который логирует информацию в консоль
- Файловый, который логирует в указанный файл

Для логирования сущностей стоит реализовать в самих сущностях методы, которые генерируют информативную строку, которая описывает сущность.

Для логера стоит поддержать возможность конфигурирации - указать нужно ли делать префикс с таймкодом в начале строки.

## Восстановление

Целью создания бекапов является предоставление возможности восстановиться из резервной копии. Требуется реализовать функционал, который бы позволял указать Restore point и восстановить данные из него. Нужно поддержать два режима восстановления:

- to original location - восстановить файл в то место, из которого они бекапились (и заменить, если они ещё существуют)
- to different location - восстановить файл в указанную папку

## Notes

1. Для проверки работоспособности алгоритма работы со временем нужно спроектировать систему так, чтобы в тестах была возможность созданным объектам задавать время создания.

# [Лабораторная 6. Reports](Reports)
## Дополнительно - REST API
> Гроб трепещет, грязная битва.
>

**Цель:** реализация многослойной архитектуры.

## Предметная область

Требуется реализовать механизм автоматизации создания отчётов о проделанной командой работе за определённый период разработки (далее - спринт). В команде один из сотрудников - тимлид, он составляет итоговый отчёт о проделанной работе команды в конце каждого спринта.

### Ход событий:

1. Сотрудник может добавлять новые задачи, вносить изменения в существующие, выполнять их.
2. Сотрудник должен писать отчёт о проделанной работе за каждый спринт. Чтобы это сделать он использует список всех изменений, произведённых с момента создания предыдущего отчёта. В течение спринта сотрудник делает отчёт, прикрепляя к нему выполненные за этот период задачи.
3. Тимлид в конце спринта пишет отчёт за всю команду, просматривая список выполненных задач и отчётов.

## Сущности

- Сотрудник. У сотрудника может быть руководитель и могут быть подчиненные.
- Задача
- Отчёт

В реализованной системе должна быть возможность добавлять новых сотрудников, изменять руководителя сотрудника и получать иерархию всех сотрудников.

Иерархия сотрудников представляется следующим образом:
тимлид - корень дерева, которому подчиняются другие сотрудники и руководители, которые могут иметь или не иметь подчинённых.
Сотрудники могут подчиняться только руководителю.


### Задача

Задача может находиться в одном из трёх состояний:

1. Open - задача создана, но к её выполнению ещё не приступили.
2. Active - задача находится в процессе выполнения.
3. Resolved - задача выполнена.

Сотрудник должен иметь возможность добавить комментарий к задаче. Все изменения (состояние/назначенный сотрудник/комментарий) должны фиксироваться во времени. При этом в системе должна быть возможность просмотреть, когда было сделано определённое изменение.

**Система управления задачами** должна поддерживать следующий функционал:

- поиск задач по ID
- поиск задач по времени создания/последнего изменения
- поиск задач, закреплённых за определённым пользователем (сотрудником команды)
- поиск задач, в которые пользователь вносил изменения
- создание задачи, изменение её состояния, добавления к ней комментария, изменение назначенного за ней сотрудника
- получение списка задач, которые назначены подчинённым определённого сотрудника

### Отчёт

Необходимо реализовать возможность написания отчётов за весь спринт. В системе на каждый спринт создается драфт отчёта (то есть черновик, начальный проект отчёта за спринт, который в дальнейшем будет корректироваться), который заполняет каждый сотрудник. Для написания отчёта пользователю системы должна предоставляться возможность получить список всех своих задач за спринт, а также список отчётов своих подчиненных за спринт.

После окончания написания отчёта за спринт сотрудник должен сохранить его в системе. После этого отчёт считается завершённым, доступ на его редактирование закрывается. Тимлид должен иметь возможность видеть статус отчёта. После того, как вся команда загрузит отчёты, тимлид имеет возможность написать общий отчёт за всю команду, который будет агрегировать все остальные.

## Интерфейс работы с пользователем

Требуется реализовать такой набор функционала:

- Сотрудники
   - Получение всех сотрудников (с пагинацией и фильтрами)
   - GetById
   - Update
   - Delete
   - Create
- **Авторизация - выставление, что работа происходит от имени определенного сотрудника (UPD: можно не делать)**
- Задачи
   - GetAll
   - поиск задач по ID
   - поиск задач по времени создания/последнего изменения
   - поиск задач, закреплённых за определённым пользователем (сотрудником команды)
   - поиск задач, в которые пользователь вносил изменения
   - создание задачи, изменение её состояния, добавления к ней комментария, изменение назначенного за ней сотрудника
   - получение списка задач, которые назначены подчинённым определённого сотрудника
   - Добавление задачи, обновление описания задачи
   - Изменение человека, который заасайнен
- Недельный отчет (викли)
   - Создать викли отчет
   - Получить список задач за эту неделю
   - Получить список дейли отчетов подчиненных (для тех, кто написал. Отдельно список тех, кто еще не написал)
   - Добавление задачи в отчет
   - Обновление описания и состояния отчета

## Детали реализации

Для этой лабораторной работы в шаблоне нет созданного проекта. Это связано с тем, что студент может выбрать способ реализации данной работы. Пример варианта реализации:

- Три простых проекта:
   - Клиент - консольное приложение, которе содержит логику работы с пользовательским интерфейсом и отправляет запросы на сервер. Может быть реализовано в виде консольного клиента (с или без использования библиотек), либо веб приложения (при большом желании можно что-то сверстать на [Blazor](https://docs.microsoft.com/en-us/learn/modules/build-blazor-webassembly-visual-studio-code/)\React\Angular\Vue).
   - Сервер - приложение, которое предоставляет API для работы с системой, предоставляет описанный в лабе функционал. Может быть реализован как ASP Web API приложение (которое довольно легко с коробки завести) либо простой TCP сервер, который обрабатывает запросы. Ознакомиться можно тут  [Tutorial: Create a web API with ASP.NET Core | Microsoft Docs](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio) и тут [An awesome guide on how to build RESTful APIs with ASP.NET Core | by Evandro Gomes | Medium](https://medium.com/free-code-camp/an-awesome-guide-on-how-to-build-restful-apis-with-asp-net-core-87b818123e28).
   - Общая сборка. Скорее всего, для общения между клиентом и сервером нужен будет контракт, описание того, какие модели между ними прокидываются. Их нужно выделить в отдельный проект т.к. клиент и сервер должны зависить от этого проекта (и не зависить друг от друга)

Если говорить про Data access layer, то можно:

- написать свою логику хранения данных используя в качестве формата JSON. Но нужно убедиться, что есть возможность после перезагрузки сервера корректно из JSON достать все нужные данные и продолжить работу
- использовать EntityFramework (и подружить его с SQLite) - ORM для работы с базой. Реализовать полноценный слой данных и получить много полезного опыта.