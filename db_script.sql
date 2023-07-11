USE MASTER
DROP DATABASE АрендаАвтомобилей

USE MASTER
GO

CREATE DATABASE АрендаАвтомобилей
ON
	(NAME = АрендаАвтомобилей_dat,
	FILENAME = 'D:\Base\АрендаАвтомобилей.mdf',
	SIZE = 5,
	MAXSIZE = 15,
	FILEGROWTH = 2)
LOG ON
	( NAME = АрендаАвтомобилей_Log,
	FILENAME = 'D:\Base\АрендаАвтомобилей.ldf',
	SIZE = 5,
	MAXSIZE = 15,
	FILEGROWTH = 2);
GO
	 
USE АрендаАвтомобилей
GO

/*  ПОЛЬЗОВАТЕЛЬСКИЕ ТИПЫ ДАННЫХ  */

CREATE TYPE PhoneNumber
FROM varchar(13)
GO

CREATE TYPE CarNumber 
FROM char(9) NOT NULL
GO

CREATE TYPE Document
FROM char(10) NOT NULL
GO

/*  УМОЛЧАНИЯ  */

CREATE DEFAULT StatusCar
AS 'Авто свободен'
GO

CREATE DEFAULT numberDefault
AS 'Номер телефона не указан'
GO

EXEC sp_bindefault 'numberDefault', 'PhoneNumber'
GO

CREATE DEFAULT FirstDay
AS getdate()
GO

CREATE DEFAULT ColorDefault
AS 'Цвет не указан'
GO

/*  ПРАВИЛА  */

CREATE RULE RussianWord 
AS
@word LIKE '[А-я]%'
GO

CREATE RULE seriesNumber
AS
@seriesFormat like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
GO

EXEC sp_bindrule 'seriesNumber', 'Document'
GO

CREATE RULE Experience
AS
@year >= 3
GO

CREATE RULE numberFormat
AS
@numberFormat like '[7-8]([0-9][0-9][0-9])[0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
GO

EXEC sp_bindrule 'numberFormat', 'PhoneNumber'
GO

CREATE RULE Polis
AS
@polisFormat like '[А-Я][А-Я][А-Я][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
GO

CREATE RULE carFormat
AS
@carFormat like '[АВЕКМНОРСТУХ][0-9][0-9][0-9][АВЕКМНОРСТУХ][АВЕКМНОРСТУХ][0-9][0-9][0-9]'
GO

EXEC sp_bindrule 'carFormat', 'CarNumber'
GO

CREATE RULE Age 
AS
DATEDIFF(year,@age,getdate()) > 20
GO

/*  СОЗДАНИЕ ТАБЛИЦ  */

create table [Страховая компания]
(
ID int NOT NULL,
[Название компании] char(20) NOT NULL,
Адрес char(50) NOT NULL
)
GO

ALTER TABLE [Страховая компания]
		ADD CONSTRAINT PK_Страховаякомпания primary key (ID)
GO

EXEC sp_bindrule 'RussianWord', '[Страховая компания].Адрес'
GO

create table Автомобили
(
[Гос. номер автомобиля] CarNumber,
Марка char(20) NOT NULL,
Модель char(20) NOT NULL,
Класс char(40) NOT NULL,
[Год выпуска] int NOT NULL,
[Тип кузова] char(20) NOT NULL,
Цвет char(20),
КПП char(4) NOT NULL,
[Цена за минуту] money NOT NULL,
[Статус авто] char(30) NOT NULL
)
GO

ALTER TABLE Автомобили
		ADD CONSTRAINT PK_Автомобили primary key ([Гос. номер автомобиля])
GO

EXEC sp_bindefault 'StatusCar', 'Автомобили.[Статус авто]'
GO

EXEC sp_bindefault 'ColorDefault', 'Автомобили.Цвет'
GO

EXEC sp_bindrule 'RussianWord', 'Автомобили.[Статус авто]' 
GO

create table [Страховой полис]
(
[Серия и номер] char(13) NOT NULL,
Компания int NOT NULL,
Автомобиль CarNumber,
[Тип страховки] char(20) NOT NULL,
[Дата начала действия] date NOT NULL,
[Дата окончания действия] date NOT NULL
)
GO

ALTER TABLE [Страховой полис]
		ADD CONSTRAINT PK_Страховойполис primary key ([Серия и номер])
GO

ALTER TABLE [Страховой полис]
		ADD CONSTRAINT FK_Страховойполис_Страховаякомпания FOREIGN KEY (Компания) REFERENCES 
[Страховая компания](ID)
GO

ALTER TABLE [Страховой полис]
		ADD CONSTRAINT FK_Страховойполис_Автомобили FOREIGN KEY (Автомобиль) REFERENCES 
Автомобили([Гос. номер автомобиля]) 
GO

EXEC sp_bindrule 'Polis', '[Страховой полис].[Серия и номер]' 
GO

create table Должности
(
ID int NOT NULL,
[Название должности] char(20) NOT NULL,
Оклад money NOT NULL
)
GO

ALTER TABLE Должности
		ADD CONSTRAINT PK_Должности primary key (ID)
GO

EXEC sp_bindrule 'RussianWord', 'Должности.[Название должности]'
GO

create table Сотрудники
(
ID int NOT NULL,
Пароль char(6) NOT NULL,
Должность int NOT NULL, 
Фамилия char(20) NOT NULL,
Имя char(20) NOT NULL,
Отчество char(20) NOT NULL,
[Дата рождения] date NOT NULL,
[Номер телефона] PhoneNumber UNIQUE,
[Дата принятия на работу] date
)
GO

ALTER TABLE Сотрудники
		ADD CONSTRAINT PK_Сотрудники primary key (ID)
GO

ALTER TABLE Сотрудники
		ADD CONSTRAINT FK_Сотрудники_Должности FOREIGN KEY (Должность) REFERENCES 
Должности(ID)
GO

EXEC sp_bindefault 'FirstDay', 'Сотрудники.[Дата принятия на работу]'
GO

EXEC sp_bindrule 'Age', 'Сотрудники.[Дата рождения]' 
GO

EXEC sp_bindrule 'RussianWord', 'Сотрудники.Фамилия' 
GO

EXEC sp_bindrule 'RussianWord', 'Сотрудники.Имя' 
GO

EXEC sp_bindrule 'RussianWord', 'Сотрудники.Отчество' 
GO

create table Автосервис
(
ID int NOT NULL,
Название char(20) NOT NULL,
Адрес char(50) NOT NULL
)
GO

ALTER TABLE Автосервис
		ADD CONSTRAINT PK_Автосервис primary key (ID)
GO

EXEC sp_bindrule 'RussianWord', 'Автосервис.Название'
GO

EXEC sp_bindrule 'RussianWord', 'Автосервис.Адрес'
GO

create table Ремонт
(
ID int NOT NULL,
[Дата сдачи] date NOT NULL, 
[Дата возврата] date NOT NULL,
Автомобиль CarNumber,
Автосервис int NOT NULL
)
GO

ALTER TABLE Ремонт
		ADD CONSTRAINT PK_Ремонт primary key (ID)
GO

ALTER TABLE Ремонт
		ADD CONSTRAINT FK_Ремонт_Автомобили FOREIGN KEY (Автомобиль) REFERENCES 
Автомобили([Гос. номер автомобиля]) 
GO

ALTER TABLE Ремонт
		ADD CONSTRAINT FK_Ремонт_Автосервис FOREIGN KEY (Автосервис) REFERENCES 
Автосервис(ID) 
GO

create table Клиенты
(
Логин char(6) NOT NULL,
Пароль char(6) NOT NULL,
Фамилия char(20) NOT NULL,
Имя char(20) NOT NULL,
Отчество char(20) NOT NULL,
[Дата рождения] date NOT NULL,
[Номер телефона] PhoneNumber UNIQUE,
Адрес char(30) NOT NULL,
Стаж int NOT NULL
)
GO

ALTER TABLE Клиенты
		ADD CONSTRAINT PK_Клиенты primary key (Логин)
GO

EXEC sp_bindrule 'Experience', 'Клиенты.Стаж' 
GO

EXEC sp_bindrule 'Age', 'Клиенты.[Дата рождения]' 
GO

EXEC sp_bindrule 'RussianWord', 'Клиенты.Фамилия'
GO

EXEC sp_bindrule 'RussianWord', 'Клиенты.Имя' 
GO

EXEC sp_bindrule 'RussianWord', 'Клиенты.Отчество' 
GO

create table Документы
(
[Серия и номер] Document,
Клиент char(6) NOT NULL,
[Дата выдачи] date NOT NULL,
[Годен до] date NOT NULL
)
GO

ALTER TABLE Документы
		ADD CONSTRAINT PK_Документы primary key ([Серия и номер])
GO

ALTER TABLE Документы
		ADD CONSTRAINT FK_Документы_Клиенты FOREIGN KEY (Клиент) REFERENCES 
Клиенты(Логин)
GO

create table [Прокат]
(
ID int NOT NULL,
Автомобиль CarNumber,
Клиент char(6) NOT NULL,
[Дата выдачи] smalldatetime NOT NULL,
[Дата возвращения] smalldatetime NOT NULL,
Стоимость money NOT NULL
)
GO

ALTER TABLE Прокат
		ADD CONSTRAINT PK_Прокат primary key (ID)
GO

ALTER TABLE Прокат
		ADD CONSTRAINT FK_Прокат_Автомобили FOREIGN KEY (Автомобиль) REFERENCES 
Автомобили([Гос. номер автомобиля]) 
GO

ALTER TABLE Прокат
		ADD CONSTRAINT FK_Прокат_Клиенты FOREIGN KEY (Клиент) REFERENCES 
Клиенты(Логин) 
GO

create table Обращение
(
ID int NOT NULL,
Клиент char(6) NOT NULL,
Сотрудник int,
[Дата обращения] date NOT NULL, 
[Описание проблемы] char(50) NOT NULL,
[Ответ на обращение] char(50) NOT NULL
)
GO

ALTER TABLE Обращение
		ADD CONSTRAINT PK_Обращение primary key (ID)
GO

ALTER TABLE Обращение
		ADD CONSTRAINT FK_Обращение_Клиенты FOREIGN KEY (Клиент) REFERENCES 
Клиенты(Логин) 
GO

ALTER TABLE Обращение
		ADD CONSTRAINT FK_Обращение_Сотрудники FOREIGN KEY (Сотрудник) REFERENCES 
Сотрудники(ID)
GO

/*  ПРЕДСТАВЛЕНИЯ  */
/*  (1) СТРАХОВКА  */

CREATE VIEW insurancePolicies
AS
SELECT [Страховой полис].[Серия и номер], [Гос. номер автомобиля], [Страховая компания].[Название компании], [Дата начала действия], [Дата окончания действия], [Тип страховки]
FROM Автомобили INNER JOIN [Страховой полис] ON 
Автомобили.[Гос. номер автомобиля] = [Страховой полис].Автомобиль 
INNER JOIN [Страховая компания] ON [Страховая компания].ID = [Страховой полис].Компания
GO

/*  (2) АВТО В РЕМОНТЕ  */

CREATE VIEW CarService
AS
SELECT Автосервис.Название AS Сервис, Автосервис.Адрес,
[Гос. номер автомобиля], Марка, Модель, Класс, [Год выпуска], [Тип кузова], Цвет, КПП, [Цена за минуту], [Статус авто],
Ремонт.[Дата сдачи], Ремонт.[Дата возврата]
FROM Автомобили JOIN Ремонт ON Автомобили.[Гос. номер автомобиля] = Ремонт.Автомобиль JOIN Автосервис ON Ремонт.Автосервис = Автосервис.ID
GO

/*  (3) СВОБОДНЫЕ АВТО  */

CREATE VIEW freeCars
AS
SELECT *
FROM Автомобили
WHERE [Статус авто] = 'Авто свободен'
GO

/*  ХРАНИМЫЕ ПРОЦЕДУРЫ  */
/*  (1) ДОБАВЛЕНИЕ АВТО  */

CREATE PROCEDURE AddCar (@carnumber char(9), @brand char(20), @model char(20), @class char(20), 
@year int, @type char(20), @color char(20), @gear char(20), @price money, @status char(30))
AS
BEGIN
INSERT INTO Автомобили
VALUES (@carnumber, @brand, @model, @class, @year, @type, @color, @gear, @price, @status)
END
GO

/*  (2) ДОБАВЛЕНИЕ КЛИЕНТА  */

CREATE PROCEDURE AddUser (@login char(6), @password char(6), @surname char(20), @name char(20), @patronymic char(20), @birthday date, @number PhoneNumber, @address char(30), @document varchar(10), @выдача date, @срок date, @experience int)
AS
BEGIN
INSERT INTO Клиенты
VALUES (@login, @password, @surname, @name, @patronymic, @birthday, @number, @address, @experience)
INSERT INTO Документы ([Серия и номер], Клиент, [Дата выдачи], [Годен до])
VALUES (@document, @login, @выдача, @срок)
END
GO

/*  (3) УДАЛЕНИЕ КЛИЕНТА  */

CREATE PROCEDURE DeleteUser (@Login char(6))
AS
BEGIN
DELETE FROM Клиенты WHERE @Login = Логин
END
GO

/*  (4) УДАЛЕНИЕ АВТО  */

CREATE PROCEDURE DeleteCar (@car CarNumber)
AS
BEGIN
DELETE FROM Автомобили WHERE [Гос. номер автомобиля] LIKE @car
END
GO

/*  (5) СДАТЬ АВТО В РЕМОНТ  */

CREATE PROCEDURE HandOverForRepair ( @dateofdelivery date, @returndate date, @carnumber char(9), @carservice int, @status char(30))
AS
BEGIN
DECLARE @id int;
SET @id = (SELECT MAX(ID)
FROM Ремонт) + 1
INSERT INTO Ремонт
VALUES (@id, @dateofdelivery, @returndate, @carnumber, @carservice)
UPDATE Автомобили
SET [Статус авто] = @status
WHERE @carnumber = [Гос. номер автомобиля]
END
GO

/*  (6) ВЕРНУТЬ АВТО ИЗ РЕМОНТА  */

CREATE PROCEDURE PickUpFromTheRepair (@id int, @carnumber char(9), @returndate date, @status char(30))
AS
BEGIN
UPDATE Ремонт
SET [Дата возврата] = @returndate
WHERE @id = ID
UPDATE Автомобили
SET [Статус авто] = @status
WHERE @carnumber = [Гос. номер автомобиля]
END
GO

/*  (7) ЗАСТРАХОВАТЬ АВТО  */

CREATE PROCEDURE InsureACar (@numberpolis char(13), @company int, @car CarNumber, @types char(20), @datestart date, @dateand date)
AS
BEGIN
INSERT INTO [Страховой полис]
VALUES (@numberpolis, @company, @car, @types, @datestart, @dateand)
END
GO

/*  (8) АРЕНДОВАТЬ АВТО  */

CREATE PROCEDURE RentACar (@car CarNumber, @client char(6), @dateofissue smalldatetime, @dateofreturn smalldatetime, @status char(30), @price money)
AS
BEGIN
DECLARE @id int
SET @id = (SELECT MAX(ID)
FROM Прокат) + 1
INSERT INTO Прокат
VALUES (@id, @car, @client, @dateofissue, @dateofreturn, @price)
UPDATE Автомобили
SET [Статус авто] = @status
WHERE @car = [Гос. номер автомобиля]
END
GO

/*  (9) ВЕРНУТЬ АВТО  */

CREATE PROCEDURE EndRent(@id int, @status char(30)) 
AS
BEGIN
DECLARE @tariff money, @car CarNumber
UPDATE Прокат
SET [Дата возвращения] = GETDATE()
WHERE ID = @id
SELECT @car = [Автомобиль] FROM Прокат WHERE [ID] = @id
SELECT @tariff = [Цена за минуту] FROM Автомобили WHERE [Гос. номер автомобиля] = @car
UPDATE Прокат
SET [Стоимость] = @tariff * DATEDIFF(minute, [Дата выдачи], [Дата возвращения])
WHERE ID = @id
UPDATE Автомобили
SET [Статус авто] = @status
WHERE @car = [Гос. номер автомобиля]
END
GO

/* ТРИГГЕРЫ */
/*  (1) ПРОСТОЙ ТРИГГЕР НА УДАЛЕНИЕ СТАРОГО ПОЛИСА */

CREATE TRIGGER DeleteIssure ON [Страховой полис]
AFTER INSERT
AS
DECLARE @car CarNumber, @document char(13) 
SELECT @car = Автомобиль, @document = [Серия и номер]
FROM inserted
DELETE FROM [Страховой полис]
WHERE @car = Автомобиль AND @document != [Серия и номер]
GO

/* (2) ПРОСТОЙ ТРИГГЕР ДЛЯ ЗАПРЕТА ЗАНЯТОГО АВТО */

CREATE TRIGGER RestrictCarRent ON Прокат
AFTER INSERT
AS
DECLARE @car CarNumber, @status char(30)
SELECT @car = Автомобиль
FROM inserted

SELECT @status = [Статус авто]
FROM Автомобили
WHERE @car = [Гос. номер автомобиля]

IF (@status != 'Авто свободен')
ROLLBACK TRAN 
PRINT ('Автомобиль занят')
GO

/*  (3) ТРИГГЕР С КУРСОСОРОМ НА УДАЛЕНИЕ АВТОМОБИЛЯ ИЗ ВСЕХ ТАБЛИЦ  */

CREATE TRIGGER DelCar ON Автомобили
INSTEAD OF DELETE
AS
	DECLARE @Car char(9);

	DECLARE Car CURSOR SCROLL FOR
		SELECT [Гос. номер автомобиля]
			FROM deleted;
	OPEN Car
	FETCH FIRST FROM Car INTO @Car;
		WHILE @@FETCH_STATUS = 0
			BEGIN
				DELETE 
					FROM Ремонт 
						WHERE Автомобиль = @Car;
				DELETE 
					FROM Прокат 
						WHERE Автомобиль = @Car;
				DELETE 
					FROM [Страховой полис] 
						WHERE Автомобиль = @Car;
				DELETE 
					FROM Автомобили 
						WHERE [Гос. номер автомобиля] = @Car;
				FETCH NEXT FROM Car INTO @Car
			END
	CLOSE Car
	DEALLOCATE Car
GO

/*  () ТРИГГЕР С КУРСОСОРОМ НА УДАЛЕНИЕ КЛИЕНТА ИЗ ВСЕХ ТАБЛИЦ  */

CREATE TRIGGER DelUser ON Клиенты
INSTEAD OF DELETE
AS
	DECLARE @User char(6);

	DECLARE UserDel CURSOR SCROLL FOR
		SELECT Логин
			FROM deleted;
	OPEN UserDel
	FETCH FIRST FROM UserDel INTO @User;
		WHILE @@FETCH_STATUS = 0
			BEGIN
				DELETE 
					FROM Обращение 
						WHERE Клиент = @User;
				DELETE 
					FROM Прокат 
						WHERE Клиент = @User;
				DELETE 
					FROM Документы 
						WHERE Клиент = @User;
				DELETE 
					FROM Клиенты 
						WHERE Логин = @User;
				FETCH NEXT FROM UserDel INTO @User
			END
	CLOSE UserDel
	DEALLOCATE UserDel
GO

/*  () ТРИГГЕР НА ЗАПРЕТ УДАЛЕНИЯ АВТОСЕРВИСА  */

CREATE TRIGGER ServiseRestrict ON Автосервис
AFTER DELETE
AS
BEGIN
ROLLBACK TRAN
PRINT 'Нельзя удалять записи из этой таблицы'
END
GO

/*  () ТРИГГЕР НА ЗАПРЕТ УДАЛЕНИЯ СТРАХОВОЙ КОМПАНИИ  */

CREATE TRIGGER IssurRestrict ON [Страховая компания]
AFTER DELETE
AS
BEGIN
ROLLBACK TRAN
PRINT 'Нельзя удалять записи из этой таблицы'
END
GO

/*  (4) ТРИГГЕР С КУРСОСОРОМ КОТОРЫЙ ПОЗВОЛЯЕТ ВНОСИТЬ ДАННЫЕ ЧЕРЕЗ ПРЕДСТАВЛЕНИЕ  */

CREATE TRIGGER ServiceView ON CarService
INSTEAD OF INSERT
AS
DECLARE @idService int, @idRepair int, @title char(20), @address char(50),
@carnumber char(9), @brand char(20), @model char(20), @class char(20), @year int, @type char(20), @color char(20), @gear char(20), @price money, @status char(30),
@carservice int, @datestart date, @returndate date
	DECLARE ServiceCursor CURSOR FOR SELECT * FROM inserted
	OPEN ServiceCursor
	FETCH NEXT FROM ServiceCursor INTO @title, @address, 
	@carnumber, @brand, @model, @class, @year, @type, @color, @gear, @price, @status,
	@datestart, @returndate
	WHILE @@FETCH_STATUS = 0
		BEGIN
		    SET @idService = (SELECT MAX(ID)
            FROM Автосервис) + 1
			INSERT INTO Автосервис(ID, Название, Адрес)
			VALUES(@idService, @title, @address)
			INSERT INTO Автомобили([Гос. номер автомобиля], Марка, Модель, Класс, [Год выпуска], 
			[Тип кузова], Цвет, КПП, [Цена за минуту], [Статус авто])
			VALUES(@carnumber, @brand, @model, @class, @year, @type, @color, @gear, @price, @status)
			SET @idRepair = (SELECT MAX(ID)
            FROM Ремонт) + 1
			INSERT INTO Ремонт(ID, Автомобиль, Автосервис, [Дата сдачи], [Дата возврата])
			VALUES(@idRepair, @carnumber, @idRepair, @datestart, @returndate)
			FETCH NEXT FROM ServiceCursor INTO @title, @address, 
			@carnumber, @brand, @model, @class, @year, @type, @color, @gear, @price, @status,
			@datestart, @returndate
		END
	CLOSE ServiceCursor
	DEALLOCATE ServiceCursor
GO

/*  (5) ТРИГГЕР С ВЛОЖЕННЫМ КУРСОРОМ ДЛЯ УДАЛЕНИЯ СОТРУДНИКОВ КОТОРЫЕ РАБОТАЛИ НА УДАЛЕННОЙ ДОЛЖНОСТИ  */

CREATE TRIGGER DeleteEmp ON Должности
INSTEAD OF DELETE
AS
	DECLARE @idPost int;
	DECLARE @idEmployee int;

	DECLARE DeletePost CURSOR SCROLL FOR
		SELECT ID
			FROM deleted;
	OPEN DeletePost
	FETCH FIRST FROM DeletePost INTO @idPost
		WHILE @@FETCH_STATUS = 0
			BEGIN
				DECLARE DeleteEmployee CURSOR SCROLL FOR
					SELECT ID
						FROM Сотрудники
							WHERE Должность = @idPost;
				OPEN DeleteEmployee
				FETCH FIRST FROM DeleteEmployee INTO @idEmployee
					WHILE @@FETCH_STATUS = 0
						BEGIN
							DELETE 
								FROM Обращение 
									WHERE Сотрудник = @idEmployee;
							
							FETCH NEXT FROM DeleteEmployee INTO @idEmployee
						END
				CLOSE DeleteEmployee
				DEALLOCATE DeleteEmployee
				DELETE 
					FROM Сотрудники 
						WHERE ID = @idEmployee;
				DELETE
					FROM Должности
						WHERE ID = @idPost;
				FETCH NEXT FROM DeletePost INTO @idPost
			END
		CLOSE DeletePost
	DEALLOCATE DeletePost
GO

/*  ЗАПОЛНЕНИЕ ТАБЛИЦ  */

INSERT INTO [Страховая компания] VALUES
	(1, 'РосГосСтрах', 'Рязань, ул.Бирюзова, 26а'),
	(2, 'Сибирь', 'Рыбное, ул.Большая, 10б'),
	(3, 'РЕСО', 'Москва, ул.Ленина, 1'),
	(5, 'ИнГосСтрах', 'Рязань, ул.Ленина, 23г'),
	(6, 'Тинькоф', 'Рязань, ул.Пирогова, 8'),
	(7, 'ВСК', 'Рязань, ул.Высоковольтная, 23'),
	(8, 'Аско', 'Рязань, ул.Шабулина, 5')
GO

INSERT INTO Автомобили VALUES 
	('х692ст062', 'BMW', '3', 'С', '2015', 'Легковая', 'Синий', 'АКПП', 50, DEFAULT),
	('н754ок777', 'Mersedes', 'C-class', 'С', '2016', 'Легковая', DEFAULT, 'АКПП', 65, DEFAULT),
	('х777сс077', 'VW', 'POLO', 'B', '2013', 'Легковая', DEFAULT, 'МКПП', 40, DEFAULT)
GO

INSERT INTO [Страховой полис] VALUES
	('ННН2394939294', 2, 'х692ст062', 'Каско', '12.12.2021', '12.12.2022'),
	('ООО2748472824', 3, 'х777сс077', 'Осаго', '14.09.2021', '14.09.2022'),
	('НОО6655665444', 1, 'н754ок777', 'Каско', '14.12.2021', '14.12.2022')
GO

INSERT INTO Должности VALUES
	(1, 'Оператор', 45000),
	(2, 'Директор', 60000),
	(3, 'Менеджер', 40000),
	(4, 'Бухгалтер', 30000)
GO

INSERT INTO Сотрудники VALUES 
	(1, 422424, 1, 'Иванов', 'Иван', 'Иванович', '29.01.1998', '8(910)3432425', '13.12.2019'),
	(2, 122113, 4, 'Кузнецов', 'Валерий', 'Федорович', '23.09.1996', '8(915)5768584', '14.05.2020'),
	(3, 348342, 2, 'Горбачев', 'Борис', 'Иванович', '23.11.1995', '8(910)5768493', '10.12.2018'),
	(4, 123456, 3, 'Козлов', 'Александр', 'Николаевич', '15.12.1989', '8(915)7489390', '24.10.2019')
GO

INSERT INTO Клиенты VALUES
	('Ivan', '123456', 'Иванов', 'Иван', 'Иванович', '29.03.1997', '8(910)3432425', 'Рязань', 8),
	('Данил', '2001', 'Белкин', 'Данил', 'Васильевич', '28.06.2000', '8(910)6319464', 'Рыбное', 10),
	('12', '976567', 'Иванов', 'Дмитрий', 'Михайлович', '12.09.1995', '8(915)2343434', 'Иркутстк', 3),
	('Miha', '124758', 'Иванов', 'Михаил', 'Михайлович', '12.12.1996', '8(910)4849304', 'Сасово', 9)
GO

INSERT INTO Документы VALUES
	('2345849503', 'Ivan', '28.11.2013', '28.11.2023'),
	('5784937568', 'Данил', '30.05.2014', '30.05.2024'),
	('6203758494', '12', '22.10.2016', '22.10.2026'),
	('5654564984', 'Miha', '14.09.2019', '24.09.2029')
GO

INSERT INTO Прокат VALUES 
	(1, 'х692ст062', 'Ivan', '23.05.2022', '24.05.2022', 200),
	(2, 'н754ок777', 'Miha', '12.07.2022', '14.07.2022', 100)
GO

INSERT INTO Обращение VALUES 
	(1, 'Ivan', 1, '28.04.2022', 'Сломана машина','Мастер выехал к вам, ожидайте'),
	(2, 'Miha', 3, '28.04.2022', 'Спустило колесо', 'Мастер выехал к вам, ожидайте')
GO

INSERT INTO Автосервис VALUES 
	(1, 'Автодом', 'Рязань'),
	(2, 'Автдруг', 'Рязань'),
	(3, 'Все свои 62', 'Рыбное'),
	(4, 'Сервис62', 'Рыбное')
GO

INSERT INTO Ремонт VALUES 
	(1, '24.05.2021', '28.12.2021' , 'х692ст062', 2),
	(2, '24.04.2021', '25.05.2021' , 'н754ок777', 1)
GO

CREATE VIEW SummRent
AS
SELECT Клиент, SUM(Стоимость) AS Сумма
FROM Прокат
GROUP BY Клиент
GO

SELECT Клиент
FROM SummRent
WHERE Сумма = (SELECT MAX(Сумма)
FROM SummRent)
GO

SELECT [Гос. номер автомобиля], MAX([Дата возврата])
FROM Автомобили LEFT JOIN Ремонт ON Автомобили.[Гос. номер автомобиля] = Ремонт.Автомобиль
GROUP BY [Гос. номер автомобиля]



SELECT Клиент
FROM Прокат
GROUP BY Клиент
HAVING SUM(Стоимость) = (SELECT MAX(SumRent)
FROM (SELECT Клиент, SUM(Стоимость) as SumRent
FROM Прокат
GROUP BY Клиент) as S)
