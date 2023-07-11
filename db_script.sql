USE MASTER
DROP DATABASE �����������������

USE MASTER
GO

CREATE DATABASE �����������������
ON
	(NAME = �����������������_dat,
	FILENAME = 'D:\Base\�����������������.mdf',
	SIZE = 5,
	MAXSIZE = 15,
	FILEGROWTH = 2)
LOG ON
	( NAME = �����������������_Log,
	FILENAME = 'D:\Base\�����������������.ldf',
	SIZE = 5,
	MAXSIZE = 15,
	FILEGROWTH = 2);
GO
	 
USE �����������������
GO

/*  ���������������� ���� ������  */

CREATE TYPE PhoneNumber
FROM varchar(13)
GO

CREATE TYPE CarNumber 
FROM char(9) NOT NULL
GO

CREATE TYPE Document
FROM char(10) NOT NULL
GO

/*  ���������  */

CREATE DEFAULT StatusCar
AS '���� ��������'
GO

CREATE DEFAULT numberDefault
AS '����� �������� �� ������'
GO

EXEC sp_bindefault 'numberDefault', 'PhoneNumber'
GO

CREATE DEFAULT FirstDay
AS getdate()
GO

CREATE DEFAULT ColorDefault
AS '���� �� ������'
GO

/*  �������  */

CREATE RULE RussianWord 
AS
@word LIKE '[�-�]%'
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
@polisFormat like '[�-�][�-�][�-�][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
GO

CREATE RULE carFormat
AS
@carFormat like '[������������][0-9][0-9][0-9][������������][������������][0-9][0-9][0-9]'
GO

EXEC sp_bindrule 'carFormat', 'CarNumber'
GO

CREATE RULE Age 
AS
DATEDIFF(year,@age,getdate()) > 20
GO

/*  �������� ������  */

create table [��������� ��������]
(
ID int NOT NULL,
[�������� ��������] char(20) NOT NULL,
����� char(50) NOT NULL
)
GO

ALTER TABLE [��������� ��������]
		ADD CONSTRAINT PK_����������������� primary key (ID)
GO

EXEC sp_bindrule 'RussianWord', '[��������� ��������].�����'
GO

create table ����������
(
[���. ����� ����������] CarNumber,
����� char(20) NOT NULL,
������ char(20) NOT NULL,
����� char(40) NOT NULL,
[��� �������] int NOT NULL,
[��� ������] char(20) NOT NULL,
���� char(20),
��� char(4) NOT NULL,
[���� �� ������] money NOT NULL,
[������ ����] char(30) NOT NULL
)
GO

ALTER TABLE ����������
		ADD CONSTRAINT PK_���������� primary key ([���. ����� ����������])
GO

EXEC sp_bindefault 'StatusCar', '����������.[������ ����]'
GO

EXEC sp_bindefault 'ColorDefault', '����������.����'
GO

EXEC sp_bindrule 'RussianWord', '����������.[������ ����]' 
GO

create table [��������� �����]
(
[����� � �����] char(13) NOT NULL,
�������� int NOT NULL,
���������� CarNumber,
[��� ���������] char(20) NOT NULL,
[���� ������ ��������] date NOT NULL,
[���� ��������� ��������] date NOT NULL
)
GO

ALTER TABLE [��������� �����]
		ADD CONSTRAINT PK_�������������� primary key ([����� � �����])
GO

ALTER TABLE [��������� �����]
		ADD CONSTRAINT FK_��������������_����������������� FOREIGN KEY (��������) REFERENCES 
[��������� ��������](ID)
GO

ALTER TABLE [��������� �����]
		ADD CONSTRAINT FK_��������������_���������� FOREIGN KEY (����������) REFERENCES 
����������([���. ����� ����������]) 
GO

EXEC sp_bindrule 'Polis', '[��������� �����].[����� � �����]' 
GO

create table ���������
(
ID int NOT NULL,
[�������� ���������] char(20) NOT NULL,
����� money NOT NULL
)
GO

ALTER TABLE ���������
		ADD CONSTRAINT PK_��������� primary key (ID)
GO

EXEC sp_bindrule 'RussianWord', '���������.[�������� ���������]'
GO

create table ����������
(
ID int NOT NULL,
������ char(6) NOT NULL,
��������� int NOT NULL, 
������� char(20) NOT NULL,
��� char(20) NOT NULL,
�������� char(20) NOT NULL,
[���� ��������] date NOT NULL,
[����� ��������] PhoneNumber UNIQUE,
[���� �������� �� ������] date
)
GO

ALTER TABLE ����������
		ADD CONSTRAINT PK_���������� primary key (ID)
GO

ALTER TABLE ����������
		ADD CONSTRAINT FK_����������_��������� FOREIGN KEY (���������) REFERENCES 
���������(ID)
GO

EXEC sp_bindefault 'FirstDay', '����������.[���� �������� �� ������]'
GO

EXEC sp_bindrule 'Age', '����������.[���� ��������]' 
GO

EXEC sp_bindrule 'RussianWord', '����������.�������' 
GO

EXEC sp_bindrule 'RussianWord', '����������.���' 
GO

EXEC sp_bindrule 'RussianWord', '����������.��������' 
GO

create table ����������
(
ID int NOT NULL,
�������� char(20) NOT NULL,
����� char(50) NOT NULL
)
GO

ALTER TABLE ����������
		ADD CONSTRAINT PK_���������� primary key (ID)
GO

EXEC sp_bindrule 'RussianWord', '����������.��������'
GO

EXEC sp_bindrule 'RussianWord', '����������.�����'
GO

create table ������
(
ID int NOT NULL,
[���� �����] date NOT NULL, 
[���� ��������] date NOT NULL,
���������� CarNumber,
���������� int NOT NULL
)
GO

ALTER TABLE ������
		ADD CONSTRAINT PK_������ primary key (ID)
GO

ALTER TABLE ������
		ADD CONSTRAINT FK_������_���������� FOREIGN KEY (����������) REFERENCES 
����������([���. ����� ����������]) 
GO

ALTER TABLE ������
		ADD CONSTRAINT FK_������_���������� FOREIGN KEY (����������) REFERENCES 
����������(ID) 
GO

create table �������
(
����� char(6) NOT NULL,
������ char(6) NOT NULL,
������� char(20) NOT NULL,
��� char(20) NOT NULL,
�������� char(20) NOT NULL,
[���� ��������] date NOT NULL,
[����� ��������] PhoneNumber UNIQUE,
����� char(30) NOT NULL,
���� int NOT NULL
)
GO

ALTER TABLE �������
		ADD CONSTRAINT PK_������� primary key (�����)
GO

EXEC sp_bindrule 'Experience', '�������.����' 
GO

EXEC sp_bindrule 'Age', '�������.[���� ��������]' 
GO

EXEC sp_bindrule 'RussianWord', '�������.�������'
GO

EXEC sp_bindrule 'RussianWord', '�������.���' 
GO

EXEC sp_bindrule 'RussianWord', '�������.��������' 
GO

create table ���������
(
[����� � �����] Document,
������ char(6) NOT NULL,
[���� ������] date NOT NULL,
[����� ��] date NOT NULL
)
GO

ALTER TABLE ���������
		ADD CONSTRAINT PK_��������� primary key ([����� � �����])
GO

ALTER TABLE ���������
		ADD CONSTRAINT FK_���������_������� FOREIGN KEY (������) REFERENCES 
�������(�����)
GO

create table [������]
(
ID int NOT NULL,
���������� CarNumber,
������ char(6) NOT NULL,
[���� ������] smalldatetime NOT NULL,
[���� �����������] smalldatetime NOT NULL,
��������� money NOT NULL
)
GO

ALTER TABLE ������
		ADD CONSTRAINT PK_������ primary key (ID)
GO

ALTER TABLE ������
		ADD CONSTRAINT FK_������_���������� FOREIGN KEY (����������) REFERENCES 
����������([���. ����� ����������]) 
GO

ALTER TABLE ������
		ADD CONSTRAINT FK_������_������� FOREIGN KEY (������) REFERENCES 
�������(�����) 
GO

create table ���������
(
ID int NOT NULL,
������ char(6) NOT NULL,
��������� int,
[���� ���������] date NOT NULL, 
[�������� ��������] char(50) NOT NULL,
[����� �� ���������] char(50) NOT NULL
)
GO

ALTER TABLE ���������
		ADD CONSTRAINT PK_��������� primary key (ID)
GO

ALTER TABLE ���������
		ADD CONSTRAINT FK_���������_������� FOREIGN KEY (������) REFERENCES 
�������(�����) 
GO

ALTER TABLE ���������
		ADD CONSTRAINT FK_���������_���������� FOREIGN KEY (���������) REFERENCES 
����������(ID)
GO

/*  �������������  */
/*  (1) ���������  */

CREATE VIEW insurancePolicies
AS
SELECT [��������� �����].[����� � �����], [���. ����� ����������], [��������� ��������].[�������� ��������], [���� ������ ��������], [���� ��������� ��������], [��� ���������]
FROM ���������� INNER JOIN [��������� �����] ON 
����������.[���. ����� ����������] = [��������� �����].���������� 
INNER JOIN [��������� ��������] ON [��������� ��������].ID = [��������� �����].��������
GO

/*  (2) ���� � �������  */

CREATE VIEW CarService
AS
SELECT ����������.�������� AS ������, ����������.�����,
[���. ����� ����������], �����, ������, �����, [��� �������], [��� ������], ����, ���, [���� �� ������], [������ ����],
������.[���� �����], ������.[���� ��������]
FROM ���������� JOIN ������ ON ����������.[���. ����� ����������] = ������.���������� JOIN ���������� ON ������.���������� = ����������.ID
GO

/*  (3) ��������� ����  */

CREATE VIEW freeCars
AS
SELECT *
FROM ����������
WHERE [������ ����] = '���� ��������'
GO

/*  �������� ���������  */
/*  (1) ���������� ����  */

CREATE PROCEDURE AddCar (@carnumber char(9), @brand char(20), @model char(20), @class char(20), 
@year int, @type char(20), @color char(20), @gear char(20), @price money, @status char(30))
AS
BEGIN
INSERT INTO ����������
VALUES (@carnumber, @brand, @model, @class, @year, @type, @color, @gear, @price, @status)
END
GO

/*  (2) ���������� �������  */

CREATE PROCEDURE AddUser (@login char(6), @password char(6), @surname char(20), @name char(20), @patronymic char(20), @birthday date, @number PhoneNumber, @address char(30), @document varchar(10), @������ date, @���� date, @experience int)
AS
BEGIN
INSERT INTO �������
VALUES (@login, @password, @surname, @name, @patronymic, @birthday, @number, @address, @experience)
INSERT INTO ��������� ([����� � �����], ������, [���� ������], [����� ��])
VALUES (@document, @login, @������, @����)
END
GO

/*  (3) �������� �������  */

CREATE PROCEDURE DeleteUser (@Login char(6))
AS
BEGIN
DELETE FROM ������� WHERE @Login = �����
END
GO

/*  (4) �������� ����  */

CREATE PROCEDURE DeleteCar (@car CarNumber)
AS
BEGIN
DELETE FROM ���������� WHERE [���. ����� ����������] LIKE @car
END
GO

/*  (5) ����� ���� � ������  */

CREATE PROCEDURE HandOverForRepair ( @dateofdelivery date, @returndate date, @carnumber char(9), @carservice int, @status char(30))
AS
BEGIN
DECLARE @id int;
SET @id = (SELECT MAX(ID)
FROM ������) + 1
INSERT INTO ������
VALUES (@id, @dateofdelivery, @returndate, @carnumber, @carservice)
UPDATE ����������
SET [������ ����] = @status
WHERE @carnumber = [���. ����� ����������]
END
GO

/*  (6) ������� ���� �� �������  */

CREATE PROCEDURE PickUpFromTheRepair (@id int, @carnumber char(9), @returndate date, @status char(30))
AS
BEGIN
UPDATE ������
SET [���� ��������] = @returndate
WHERE @id = ID
UPDATE ����������
SET [������ ����] = @status
WHERE @carnumber = [���. ����� ����������]
END
GO

/*  (7) ������������ ����  */

CREATE PROCEDURE InsureACar (@numberpolis char(13), @company int, @car CarNumber, @types char(20), @datestart date, @dateand date)
AS
BEGIN
INSERT INTO [��������� �����]
VALUES (@numberpolis, @company, @car, @types, @datestart, @dateand)
END
GO

/*  (8) ���������� ����  */

CREATE PROCEDURE RentACar (@car CarNumber, @client char(6), @dateofissue smalldatetime, @dateofreturn smalldatetime, @status char(30), @price money)
AS
BEGIN
DECLARE @id int
SET @id = (SELECT MAX(ID)
FROM ������) + 1
INSERT INTO ������
VALUES (@id, @car, @client, @dateofissue, @dateofreturn, @price)
UPDATE ����������
SET [������ ����] = @status
WHERE @car = [���. ����� ����������]
END
GO

/*  (9) ������� ����  */

CREATE PROCEDURE EndRent(@id int, @status char(30)) 
AS
BEGIN
DECLARE @tariff money, @car CarNumber
UPDATE ������
SET [���� �����������] = GETDATE()
WHERE ID = @id
SELECT @car = [����������] FROM ������ WHERE [ID] = @id
SELECT @tariff = [���� �� ������] FROM ���������� WHERE [���. ����� ����������] = @car
UPDATE ������
SET [���������] = @tariff * DATEDIFF(minute, [���� ������], [���� �����������])
WHERE ID = @id
UPDATE ����������
SET [������ ����] = @status
WHERE @car = [���. ����� ����������]
END
GO

/* �������� */
/*  (1) ������� ������� �� �������� ������� ������ */

CREATE TRIGGER DeleteIssure ON [��������� �����]
AFTER INSERT
AS
DECLARE @car CarNumber, @document char(13) 
SELECT @car = ����������, @document = [����� � �����]
FROM inserted
DELETE FROM [��������� �����]
WHERE @car = ���������� AND @document != [����� � �����]
GO

/* (2) ������� ������� ��� ������� �������� ���� */

CREATE TRIGGER RestrictCarRent ON ������
AFTER INSERT
AS
DECLARE @car CarNumber, @status char(30)
SELECT @car = ����������
FROM inserted

SELECT @status = [������ ����]
FROM ����������
WHERE @car = [���. ����� ����������]

IF (@status != '���� ��������')
ROLLBACK TRAN 
PRINT ('���������� �����')
GO

/*  (3) ������� � ���������� �� �������� ���������� �� ���� ������  */

CREATE TRIGGER DelCar ON ����������
INSTEAD OF DELETE
AS
	DECLARE @Car char(9);

	DECLARE Car CURSOR SCROLL FOR
		SELECT [���. ����� ����������]
			FROM deleted;
	OPEN Car
	FETCH FIRST FROM Car INTO @Car;
		WHILE @@FETCH_STATUS = 0
			BEGIN
				DELETE 
					FROM ������ 
						WHERE ���������� = @Car;
				DELETE 
					FROM ������ 
						WHERE ���������� = @Car;
				DELETE 
					FROM [��������� �����] 
						WHERE ���������� = @Car;
				DELETE 
					FROM ���������� 
						WHERE [���. ����� ����������] = @Car;
				FETCH NEXT FROM Car INTO @Car
			END
	CLOSE Car
	DEALLOCATE Car
GO

/*  () ������� � ���������� �� �������� ������� �� ���� ������  */

CREATE TRIGGER DelUser ON �������
INSTEAD OF DELETE
AS
	DECLARE @User char(6);

	DECLARE UserDel CURSOR SCROLL FOR
		SELECT �����
			FROM deleted;
	OPEN UserDel
	FETCH FIRST FROM UserDel INTO @User;
		WHILE @@FETCH_STATUS = 0
			BEGIN
				DELETE 
					FROM ��������� 
						WHERE ������ = @User;
				DELETE 
					FROM ������ 
						WHERE ������ = @User;
				DELETE 
					FROM ��������� 
						WHERE ������ = @User;
				DELETE 
					FROM ������� 
						WHERE ����� = @User;
				FETCH NEXT FROM UserDel INTO @User
			END
	CLOSE UserDel
	DEALLOCATE UserDel
GO

/*  () ������� �� ������ �������� �����������  */

CREATE TRIGGER ServiseRestrict ON ����������
AFTER DELETE
AS
BEGIN
ROLLBACK TRAN
PRINT '������ ������� ������ �� ���� �������'
END
GO

/*  () ������� �� ������ �������� ��������� ��������  */

CREATE TRIGGER IssurRestrict ON [��������� ��������]
AFTER DELETE
AS
BEGIN
ROLLBACK TRAN
PRINT '������ ������� ������ �� ���� �������'
END
GO

/*  (4) ������� � ���������� ������� ��������� ������� ������ ����� �������������  */

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
            FROM ����������) + 1
			INSERT INTO ����������(ID, ��������, �����)
			VALUES(@idService, @title, @address)
			INSERT INTO ����������([���. ����� ����������], �����, ������, �����, [��� �������], 
			[��� ������], ����, ���, [���� �� ������], [������ ����])
			VALUES(@carnumber, @brand, @model, @class, @year, @type, @color, @gear, @price, @status)
			SET @idRepair = (SELECT MAX(ID)
            FROM ������) + 1
			INSERT INTO ������(ID, ����������, ����������, [���� �����], [���� ��������])
			VALUES(@idRepair, @carnumber, @idRepair, @datestart, @returndate)
			FETCH NEXT FROM ServiceCursor INTO @title, @address, 
			@carnumber, @brand, @model, @class, @year, @type, @color, @gear, @price, @status,
			@datestart, @returndate
		END
	CLOSE ServiceCursor
	DEALLOCATE ServiceCursor
GO

/*  (5) ������� � ��������� �������� ��� �������� ����������� ������� �������� �� ��������� ���������  */

CREATE TRIGGER DeleteEmp ON ���������
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
						FROM ����������
							WHERE ��������� = @idPost;
				OPEN DeleteEmployee
				FETCH FIRST FROM DeleteEmployee INTO @idEmployee
					WHILE @@FETCH_STATUS = 0
						BEGIN
							DELETE 
								FROM ��������� 
									WHERE ��������� = @idEmployee;
							
							FETCH NEXT FROM DeleteEmployee INTO @idEmployee
						END
				CLOSE DeleteEmployee
				DEALLOCATE DeleteEmployee
				DELETE 
					FROM ���������� 
						WHERE ID = @idEmployee;
				DELETE
					FROM ���������
						WHERE ID = @idPost;
				FETCH NEXT FROM DeletePost INTO @idPost
			END
		CLOSE DeletePost
	DEALLOCATE DeletePost
GO

/*  ���������� ������  */

INSERT INTO [��������� ��������] VALUES
	(1, '�����������', '������, ��.��������, 26�'),
	(2, '������', '������, ��.�������, 10�'),
	(3, '����', '������, ��.������, 1'),
	(5, '����������', '������, ��.������, 23�'),
	(6, '�������', '������, ��.��������, 8'),
	(7, '���', '������, ��.��������������, 23'),
	(8, '����', '������, ��.��������, 5')
GO

INSERT INTO ���������� VALUES 
	('�692��062', 'BMW', '3', '�', '2015', '��������', '�����', '����', 50, DEFAULT),
	('�754��777', 'Mersedes', 'C-class', '�', '2016', '��������', DEFAULT, '����', 65, DEFAULT),
	('�777��077', 'VW', 'POLO', 'B', '2013', '��������', DEFAULT, '����', 40, DEFAULT)
GO

INSERT INTO [��������� �����] VALUES
	('���2394939294', 2, '�692��062', '�����', '12.12.2021', '12.12.2022'),
	('���2748472824', 3, '�777��077', '�����', '14.09.2021', '14.09.2022'),
	('���6655665444', 1, '�754��777', '�����', '14.12.2021', '14.12.2022')
GO

INSERT INTO ��������� VALUES
	(1, '��������', 45000),
	(2, '��������', 60000),
	(3, '��������', 40000),
	(4, '���������', 30000)
GO

INSERT INTO ���������� VALUES 
	(1, 422424, 1, '������', '����', '��������', '29.01.1998', '8(910)3432425', '13.12.2019'),
	(2, 122113, 4, '��������', '�������', '���������', '23.09.1996', '8(915)5768584', '14.05.2020'),
	(3, 348342, 2, '��������', '�����', '��������', '23.11.1995', '8(910)5768493', '10.12.2018'),
	(4, 123456, 3, '������', '���������', '����������', '15.12.1989', '8(915)7489390', '24.10.2019')
GO

INSERT INTO ������� VALUES
	('Ivan', '123456', '������', '����', '��������', '29.03.1997', '8(910)3432425', '������', 8),
	('�����', '2001', '������', '�����', '����������', '28.06.2000', '8(910)6319464', '������', 10),
	('12', '976567', '������', '�������', '����������', '12.09.1995', '8(915)2343434', '��������', 3),
	('Miha', '124758', '������', '������', '����������', '12.12.1996', '8(910)4849304', '������', 9)
GO

INSERT INTO ��������� VALUES
	('2345849503', 'Ivan', '28.11.2013', '28.11.2023'),
	('5784937568', '�����', '30.05.2014', '30.05.2024'),
	('6203758494', '12', '22.10.2016', '22.10.2026'),
	('5654564984', 'Miha', '14.09.2019', '24.09.2029')
GO

INSERT INTO ������ VALUES 
	(1, '�692��062', 'Ivan', '23.05.2022', '24.05.2022', 200),
	(2, '�754��777', 'Miha', '12.07.2022', '14.07.2022', 100)
GO

INSERT INTO ��������� VALUES 
	(1, 'Ivan', 1, '28.04.2022', '������� ������','������ ������ � ���, ��������'),
	(2, 'Miha', 3, '28.04.2022', '�������� ������', '������ ������ � ���, ��������')
GO

INSERT INTO ���������� VALUES 
	(1, '�������', '������'),
	(2, '�������', '������'),
	(3, '��� ���� 62', '������'),
	(4, '������62', '������')
GO

INSERT INTO ������ VALUES 
	(1, '24.05.2021', '28.12.2021' , '�692��062', 2),
	(2, '24.04.2021', '25.05.2021' , '�754��777', 1)
GO

CREATE VIEW SummRent
AS
SELECT ������, SUM(���������) AS �����
FROM ������
GROUP BY ������
GO

SELECT ������
FROM SummRent
WHERE ����� = (SELECT MAX(�����)
FROM SummRent)
GO

SELECT [���. ����� ����������], MAX([���� ��������])
FROM ���������� LEFT JOIN ������ ON ����������.[���. ����� ����������] = ������.����������
GROUP BY [���. ����� ����������]



SELECT ������
FROM ������
GROUP BY ������
HAVING SUM(���������) = (SELECT MAX(SumRent)
FROM (SELECT ������, SUM(���������) as SumRent
FROM ������
GROUP BY ������) as S)
