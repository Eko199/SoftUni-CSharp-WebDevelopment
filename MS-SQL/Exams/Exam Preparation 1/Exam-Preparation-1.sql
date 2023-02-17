--Section 1. DDL
CREATE DATABASE Zoo;
GO
USE Zoo;
GO

--01.
CREATE TABLE Owners (
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	Address VARCHAR(50)
);

CREATE TABLE AnimalTypes (
	Id INT PRIMARY KEY IDENTITY,
	AnimalType VARCHAR(30) NOT NULL
);

CREATE TABLE Cages (
	Id INT PRIMARY KEY IDENTITY,
	AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
);

CREATE TABLE Animals (
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(30) NOT NULL,
	BirthDate DATE NOT NULL,
	OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
	AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
);

CREATE TABLE AnimalsCages (
	CageId INT FOREIGN KEY REFERENCES Cages(Id) NOT NULL,
	AnimalId INT FOREIGN KEY REFERENCES Animals(Id) NOT NULL,
	PRIMARY KEY(CageId, AnimalId)
);

CREATE TABLE VolunteersDepartments (
	Id INT PRIMARY KEY IDENTITY,
	DepartmentName VARCHAR(30) NOT NULL
);

CREATE TABLE Volunteers (
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	Address VARCHAR(50),
	AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
	DepartmentId INT FOREIGN KEY REFERENCES VolunteersDepartments(Id) NOT NULL
);

--Section 2. DML
--02.
INSERT INTO Volunteers
VALUES
	('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
	('Dimitur Stoev', '0877564223', NULL, 42, 4),
	('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
	('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
	('Boryana Mileva', '0888112233', NULL, 31, 5);

INSERT INTO Animals
VALUES
	('Giraffe', '2018-09-21', 21, 1),
	('Harpy Eagle', '2015-04-17', 15, 3),
	('Hamadryas Baboon', '2017-11-02', NULL, 1),
	('Tuatara', '2021-06-30', 2, 4);

--03.
UPDATE Animals
SET OwnerId = (SELECT Id FROM Owners WHERE Name = 'Kaloqn Stoqnov')
WHERE OwnerId IS NULL;

--04.
DECLARE @departmentToBeDeletedId INT = (
	SELECT Id 
	FROM VolunteersDepartments 
	WHERE DepartmentName = 'Education program assistant'
);

DELETE Volunteers
WHERE DepartmentId = @departmentToBeDeletedId;

DELETE VolunteersDepartments
WHERE Id = @departmentToBeDeletedId;

--Section 3. Querying
--05.
SELECT Name, PhoneNumber, Address, AnimalId, DepartmentId
FROM Volunteers
ORDER BY Name, AnimalId, DepartmentId;

--06.
SELECT Name, AnimalType, FORMAT(BirthDate, 'dd.MM.yyyy') AS BirthDate
FROM Animals AS a
JOIN AnimalTypes AS at ON a.AnimalTypeId = at.Id
ORDER BY Name;

--07.
SELECT TOP(5) o.Name, COUNT(*) AS CountOfAnimals
FROM Animals AS a
RIGHT JOIN Owners AS o ON a.OwnerId = o.Id
GROUP BY o.Name
ORDER BY CountOfAnimals DESC, o.Name;

--08.
SELECT
	CONCAT(o.Name, '-', a.Name) AS OwnersAnimals
	,PhoneNumber
	,CageId
FROM Animals AS a
JOIN AnimalTypes AS at ON a.AnimalTypeId = at.Id
JOIN Owners AS o ON a.OwnerId = o.Id
JOIN AnimalsCages AS ac ON a.Id = ac.AnimalId
WHERE AnimalType = 'Mammals'
ORDER BY o.Name, a.Name DESC;

--09.
SELECT Name
	,PhoneNumber
	,LTRIM(REPLACE(REPLACE(Address, 'Sofia', ''), ',', '')) AS Address
FROM Volunteers
WHERE DepartmentId = (
	SELECT Id
	FROM VolunteersDepartments
	WHERE DepartmentName = 'Education program assistant'
)
AND LTRIM(Address) LIKE 'Sofia%'
ORDER BY Name;

--10.
SELECT Name, YEAR(BirthDate) AS BirthYear, AnimalType
FROM Animals AS a
JOIN AnimalTypes AS at ON a.AnimalTypeId = at.Id
WHERE OwnerId IS NULL
AND YEAR(BirthDate) > 2017
AND AnimalType <> 'Birds'
ORDER BY Name;

--11.
GO
CREATE FUNCTION udf_GetVolunteersCountFromADepartment(@VolunteersDepartment VARCHAR(30))
RETURNS INT AS
BEGIN
	RETURN (
		SELECT COUNT(*)
		FROM Volunteers AS v
		JOIN VolunteersDepartments AS d ON v.DepartmentId = d.Id
		WHERE DepartmentName = @VolunteersDepartment
	);
END
GO

--12
CREATE PROC usp_AnimalsWithOwnersOrNot @AnimalName VARCHAR(30)
AS
BEGIN
	SELECT a.Name, ISNULL(o.Name, 'For adoption') AS OwnersName
	FROM Animals AS a
	LEFT JOIN Owners AS o ON a.OwnerId = o.Id
	WHERE a.Name = @AnimalName;
END