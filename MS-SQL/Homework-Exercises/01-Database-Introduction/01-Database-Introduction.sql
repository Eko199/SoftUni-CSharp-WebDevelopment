--1.
CREATE DATABASE Minions;

--2.
USE Minions;

CREATE TABLE Minions (
	Id INT PRIMARY KEY,
	Name VARCHAR(30),
	Age TINYINT
);

CREATE TABLE Towns (
	Id INT PRIMARY KEY,
	Name VARCHAR(30)
);

--3.
ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id);

--4.
INSERT INTO Towns
VALUES
	(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna');

INSERT INTO Minions
VALUES
	(1, 'Kevin', 22, 1),
	(2, 'Bob', 15, 3),
	(3, 'Steward', NULL, 2);

--5.
TRUNCATE TABLE Minions;

--6.
DROP TABLE Minions;
DROP TABLE Towns;

--7.
CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX) CHECK(LEN(Picture) <= 2000000),
	Height DECIMAL(3, 2),
	Weight DECIMAL(5, 2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATETIME2 NOT NULL,
	Biography NVARCHAR(MAX)
);

INSERT INTO People (Name, Gender, Birthdate)
VALUES
	('Asdf', 'm', '1999-12-12'),
	('Asdf', 'm', '1999-12-12'),
	('Asdf', 'f', '1999-12-09'),
	('Asdf', 'f', '1999-12-11'),
	('Asdf', 'f', '1999-12-10');

--8.
CREATE TABLE Users (
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	Password VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX) CHECK(LEN(ProfilePicture) <= 900000),
	LastLoginTime DATETIME2,
	IsDeleted BIT
);

INSERT INTO Users (Username, Password)
VALUES
	('Asdf', '19929-12-12'),
	('Asdf1', '19599-12-12'),
	('Asdf2', '19993452-12-09'),
	('Asdf3', '196799-12-11'),
	('Asdf4', '1999567-12-10');

--9.
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07CDD122E1;

ALTER TABLE Users
ADD CONSTRAINT PK__Users__3214EC07CDD122E1 PRIMARY KEY(Id, Username);

--10.
ALTER TABLE Users
ADD CHECK(LEN(Password) >= 5);

--11.
ALTER TABLE Users
ADD DEFAULT GETDATE() FOR LastLoginTime;

--12.
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07CDD122E1;

ALTER TABLE Users
ADD PRIMARY KEY(Id);

ALTER TABLE Users
ADD Unique(Username);

ALTER TABLE Users
ADD CHECK(LEN(Username) >= 3);

--13.
CREATE DATABASE Movies;
GO
USE Movies;

CREATE TABLE Directors (
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
);

CREATE TABLE Genres (
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
);

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
);

CREATE TABLE Movies (
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(40) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear SMALLINT NOT NULL,
	Length INT,
	GenreId INT,
	CategoryId INT,
	Rating DECIMAL(4, 2),
	Notes NVARCHAR(MAX)
);

INSERT INTO Directors (DirectorName)
VALUES
	('Pesho'),
	('Pesho1'),
	('Pesho2'),
	('Pesho3'),
	('Pesho4');

INSERT INTO Genres (GenreName)
VALUES
	('Asdf'),
	('Asdf1'),
	('Asdf2'),
	('Asdf3'),
	('Asdf4');

INSERT INTO Categories (CategoryName)
VALUES
	('Categoria'),
	('Categoria1'),
	('Categoria2'),
	('Categoria3'),
	('Categoria4');

INSERT INTO Movies (Title, DirectorId, CopyrightYear)
VALUES
	('1', 1, 2022),
	('2', 2, 2021),
	('3', 3, 2020),
	('4', 4, 2019),
	('5', 5, 2018);

--14.
CREATE DATABASE CarRental;
GO
USE CarRental;

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(20) NOT NULL,
	DailyRate DECIMAL(4, 2) NOT NULL,
	WeeklyRate DECIMAL(4, 2) NOT NULL,
	MonthlyRate DECIMAL(4, 2) NOT NULL,
	WeekendRate DECIMAL(4, 2) NOT NULL,
);

CREATE TABLE Cars (
	Id INT PRIMARY KEY IDENTITY, 
	PlateNumber VARCHAR(10) NOT NULL, 
	Manufacturer NVARCHAR(30), 
	Model NVARCHAR(30) NOT NULL, 
	CarYear SMALLINT, 
	CategoryId INT, 
	Doors TINYINT, 
	Picture VARBINARY(MAX), 
	Condition NVARCHAR(MAX), 
	Available BIT NOT NULL
);

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(30) NOT NULL, 
	LastName NVARCHAR(30) NOT NULL, 
	Title NVARCHAR(30), 
	Notes NVARCHAR(MAX)
);

CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY, 
	DriverLicenceNumber VARCHAR(20) NOT NULL, 
	FullName NVARCHAR(60) NOT NULL, 
	Address NVARCHAR(100), 
	City NVARCHAR(20), 
	ZIPCode SMALLINT, 
	Notes NVARCHAR(MAX)
);

CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT NOT NULL, 
	CustomerId INT NOT NULL, 
	CarId INT NOT NULL, 
	TankLevel INT, 
	KilometrageStart DECIMAL(8, 2),
	KilometrageEnd DECIMAL(8, 2), 
	TotalKilometrage DECIMAL(8, 2), 
	StartDate DATETIME2, 
	EndDate DATETIME2, 
	TotalDays INT, 
	RateApplied DECIMAL(4, 2), 
	TaxRate DECIMAL(4, 2), 
	OrderStatus NVARCHAR(100), 
	Notes NVARCHAR(MAX)
);

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
	('Asdf1', 1.2, 8.4, 33.6, 2),
	('Asdf2', 1.3, 9.1, 36.4, 3),
	('Asdf3', 1.4, 9.8, 38.2, 2);

INSERT INTO Cars (PlateNumber, Model, Available)
VALUES
	('3451300', 'zxcbaseb', 1),
	('0123456', 'nwer', 1),
	('2345DHJ', 'wertg', 0);

INSERT INTO Employees (FirstName, LastName)
VALUES
	('Aa', 'Bb'),
	('Cc', 'Dd'),
	('Ee', 'Ff');

INSERT INTO Customers (DriverLicenceNumber, FullName)
VALUES
	('34567425', 'Ajierf Utyu'),
	('02457457', 'Bjiow Kbhe'),
	('74563477', 'Bferik Lweb');

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId)
VALUES
	(1, 3, 2),
	(2, 2, 3),
	(3, 1, 1);

--15.
CREATE DATABASE Hotel;
GO
USE Hotel;

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(30) NOT NULL, 
	LastName NVARCHAR(30) NOT NULL, 
	Title NVARCHAR(30), 
	Notes NVARCHAR(MAX)
);

CREATE TABLE Customers (
	AccountNumber INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(30) NOT NULL, 
	LastName NVARCHAR(30) NOT NULL, 
	PhoneNumber CHAR(10), 
	EmergencyName NVARCHAR(30) NOT NULL, 
	EmergencyNumber CHAR(3) NOT NULL, 
	Notes NVARCHAR(MAX)
);

CREATE TABLE RoomStatus (
	Id INT PRIMARY KEY IDENTITY, 
	RoomStatus NVARCHAR(30) NOT NULL, 
	Notes NVARCHAR(MAX)
);

CREATE TABLE RoomTypes (
	Id INT PRIMARY KEY IDENTITY, 
	RoomType NVARCHAR(30) NOT NULL, 
	Notes NVARCHAR(MAX)
);

CREATE TABLE BedTypes (
	Id INT PRIMARY KEY IDENTITY, 
	BedType NVARCHAR(30) NOT NULL, 
	Notes NVARCHAR(MAX)
);

CREATE TABLE Rooms (
	RoomNumber INT PRIMARY KEY IDENTITY, 
	RoomType INT NOT NULL, 
	BedType INT NOT NULL, 
	Rate DECIMAL(4, 2) NOT NULL, 
	RoomStatus INT NOT NULL, 
	Notes NVARCHAR(MAX)
);

CREATE TABLE Payments (
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT NOT NULL, 
	PaymentDate DATETIME2 NOT NULL, 
	AccountNumber INT NOT NULL, 
	FirstDateOccupied DATETIME2 NOT NULL, 
	LastDateOccupied DATETIME2 NOT NULL, 
	TotalDays SMALLINT NOT NULL, 
	AmountCharged DECIMAL(6, 2) NOT NULL, 
	TaxRate DECIMAL(6, 2), 
	TaxAmount DECIMAL(6, 2), 
	PaymentTotal DECIMAL(6, 2) NOT NULL, 
	Notes NVARCHAR(MAX)
);

CREATE TABLE Occupancies (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL, 
	DateOccupied DATETIME2 NOT NULL, 
	AccountNumber INT NOT NULL, 
	RoomNumber INT NOT NULL, 
	RateApplied DECIMAL(6, 2), 
	PhoneCharge DECIMAL(5, 2), 
	Notes NVARCHAR(MAX)
);

INSERT INTO Employees (FirstName, LastName)
VALUES
	('Aa', 'Bb'),
	('Cc', 'Dd'),
	('Ee', 'Ff');

INSERT INTO Customers (FirstName, LastName, EmergencyName, EmergencyNumber)
VALUES
	('Ajierf', 'Utyu', 'HELP','112'),
	('Bjiow', 'Kbhe', 'HELP','112'),
	('Bferik', 'Lweb', 'HELP','112');

INSERT INTO RoomStatus (RoomStatus)
VALUES ('RoomStatus1'), ('RoomStatus2'), ('RoomStatus3');

INSERT INTO RoomTypes (RoomType)
VALUES ('RoomType1'), ('RoomType2'), ('RoomType3');

INSERT INTO BedTypes (BedType)
VALUES ('BedType1'), ('BedType2'), ('BedType3');

INSERT INTO Rooms (RoomType, BedType, Rate, RoomStatus)
VALUES
	(2, 2, 13.3, 1),
	(3, 3, 15.3, 2),
	(1, 1, 9.3, 3);

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, PaymentTotal)
VALUES
	(1, '2023-01-01', 3, '2022-12-20', '2022-12-31', 12, 445.49, 445.49),
	(2, '2023-01-01', 2, '2022-12-10', '2022-12-31', 22, 545.49, 545.49),
	(3, '2023-01-01', 1, '2022-12-30', '2022-12-31', 2, 345.49, 345.49);

INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber)
VALUES
	(1, '2022-12-20', 3, 1),
	(2, '2022-12-10', 2, 2),
	(3, '2022-12-30', 1, 3);

--16.
CREATE DATABASE SoftUni;
GO
USE SoftUni;

CREATE TABLE Towns (
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(20) NOT NULL
);

CREATE TABLE Addresses (
	Id INT PRIMARY KEY IDENTITY, 
	AddressText NVARCHAR(100) NOT NULL, 
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
);

CREATE TABLE Departments (
	Id INT PRIMARY KEY IDENTITY, 
	Name NVARCHAR(30) NOT NULL
);

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(30) NOT NULL, 
	MiddleName NVARCHAR(30), 
	LastName NVARCHAR(30) NOT NULL, 
	JobTitle NVARCHAR(20), 
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL, 
	HireDate DATETIME2, 
	Salary DECIMAL(7, 2), 
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
);

--17.
USE master;
GO
RESTORE DATABASE SoftUni
FROM DISK = 'C:\Users\asusv\source\repos\SoftUni-CSharp-WebDevelopment\MS-SQL\Homework-Exercises\01-Database-Introduction\softuni-backup.bak';

--18.
USE SoftUni;

INSERT INTO Towns (Name)
VALUES ('Sofia'), ('Plovdiv'), ('Varna'), ('Burgas');

INSERT INTO Departments(Name)
VALUES ('Engineering'), ('Sales'), ('Marketing'), ('Software Development'), ('Quality Assurance');

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES
	('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
	('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
	('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-25', 525.25),
	('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2006-12-09', 3000.00),
	('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88);

--19.
SELECT * FROM Towns;
SELECT * FROM Departments;
SELECT * FROM Employees;

--20.
SELECT * FROM Towns
ORDER BY Name;

SELECT * FROM Departments
ORDER BY Name;

SELECT * FROM Employees
ORDER BY Salary DESC;

--21.
SELECT Name FROM Towns
ORDER BY Name;

SELECT Name FROM Departments
ORDER BY Name;

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC;

--22.
UPDATE Employees
SET Salary = Salary * 1.1;

SELECT Salary From Employees;

--23.
USE Hotel;

UPDATE Payments
SET TaxRate = TaxRate * 0.97;

SELECT TaxRate FROM Payments;

--24.
TRUNCATE TABLE Occupancies;