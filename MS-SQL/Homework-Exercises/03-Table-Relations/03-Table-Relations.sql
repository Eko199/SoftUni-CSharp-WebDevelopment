CREATE DATABASE TableRelations;
GO
USE TableRelations;

--01.
CREATE TABLE Passports (
	PassportID INT PRIMARY KEY IDENTITY(101, 1),
	PassportNumber CHAR(8) NOT NULL UNIQUE
);

CREATE TABLE Persons (
	PersonID INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	Salary DECIMAL(8, 2),
	PassportID INT UNIQUE FOREIGN KEY REFERENCES Passports(PassportID)
);

INSERT INTO Passports (PassportNumber)
VALUES ('N34FG21B'), ('K65LO4R7'), ('ZE657QP2');

INSERT INTO Persons (FirstName, Salary, PassportID)
VALUES
	('Roberto', 43300, 102),
	('Tom', 56100, 103),
	('Yana', 60200, 101);

--02.
CREATE TABLE Manufacturers (
	ManufacturerID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(30) NOT NULL,
	EstablishedOn DATETIME2
);

CREATE TABLE Models (
	ModelID INT PRIMARY KEY IDENTITY(101, 1),
	Name VARCHAR(50) NOT NULL,
	ManufacturerID INT NOT NULL FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
);

INSERT INTO Manufacturers (Name, EstablishedOn)
VALUES
	('BMW', '07/03/1916'),
	('Tesla', '01/01/2003'),
	('Lada', '01/05/1966');

INSERT INTO Models (Name, ManufacturerID)
VALUES
	('X1', 1),
	('i6', 1),
	('Model S', 2),
	('Model X', 2),
	('Model 3', 2),
	('Nova', 3);

--03.
CREATE TABLE Students (
	StudentID INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(20) NOT NULL
);

CREATE TABLE Exams (
	ExamID INT PRIMARY KEY IDENTITY(101, 1),
	Name NVARCHAR(50) NOT NULL
);

CREATE TABLE StudentsExams (
	StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT NOT NULL FOREIGN KEY REFERENCES Exams(ExamID),
	PRIMARY KEY (StudentID, ExamID)
);

INSERT INTO Students (Name)
VALUES ('Mila'), ('Toni'), ('Ron');

INSERT INTO Exams (Name)
VALUES ('SpringMVC'), ('Neo4j'), ('Oracle 11g');

INSERT INTO StudentsExams
VALUES
	(1, 101),
	(1, 102),
	(2, 101),
	(3, 103),
	(2, 102),
	(2, 103);

--04.
CREATE TABLE Teachers (
	TeacherID INT PRIMARY KEY IDENTITY(101, 1),
	Name NVARCHAR(20) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
);

INSERT INTO Teachers (Name, ManagerID)
VALUES
	('John', NULL),
	('Maya', 106),
	('Silvia', 106),
	('Ted', 105),
	('Mark', 101),
	('Greta', 101);

--05.
CREATE DATABASE OnlineStore;
GO
USE OnlineStore;

CREATE TABLE Cities (
	CityID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL
);

CREATE TABLE Customers (
	CustomerID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	Birthday DATETIME2,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID)
);

CREATE TABLE Orders (
	OrderID INT PRIMARY KEY IDENTITY,
	CustomerID INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerID)
);

CREATE TABLE ItemTypes (
	ItemTypeID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(30) NOT NULL
);

CREATE TABLE Items (
	ItemID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(30) NOT NULL,
	ItemTypeID INT NOT NULL FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
);

CREATE TABLE OrderItems(
	OrderID INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderID),
	ItemID INT NOT NULL FOREIGN KEY REFERENCES Items(ItemID),
	PRIMARY KEY (OrderID, ItemID)
);

--06.
CREATE DATABASE University;
GO
USE University;

CREATE TABLE Majors (
	MajorID INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL
);

CREATE TABLE Students (
	StudentID INT PRIMARY KEY IDENTITY,
	StudentNumber VARCHAR(10) NOT NULL,
	StudentName VARCHAR(30) NOT NULL,
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
);

CREATE TABLE Payments (
	PaymentID INT PRIMARY KEY IDENTITY,
	PaymentDate DATETIME2 NOT NULL,
	PaymentAmount DECIMAL(8, 2) NOT NULL,
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
);

CREATE TABLE Subjects (
	SubjectID INT PRIMARY KEY IDENTITY,
	SubjectName VARCHAR(50) NOT NULL
);

CREATE TABLE Agenda (
	StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID INT NOT NULL FOREIGN KEY REFERENCES Subjects(SubjectID),
	PRIMARY KEY (StudentID, SubjectID)
);

--09.
USE Geography;

SELECT MountainRange, PeakName, Elevation
FROM Mountains AS m
JOIN Peaks ON m.Id = MountainId
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC;