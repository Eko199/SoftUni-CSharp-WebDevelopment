--Part 1
USE SoftUni;
GO

--01.
SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'Sa%';

--02.
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%';

--03.
SELECT FirstName
FROM Employees
WHERE DepartmentID IN (3, 10)
AND YEAR(HireDate) BETWEEN 1995 AND 2005;

--04.
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%';

--05.
SELECT Name
FROM Towns
WHERE LEN(Name) IN (5, 6)
ORDER BY Name;

--06.
SELECT *
FROM Towns
WHERE LEFT(Name, 1) IN ('M', 'K', 'B', 'E')
ORDER BY Name;

--07.
SELECT *
FROM Towns
WHERE LEFT(Name, 1) NOT IN ('R', 'B', 'D')
ORDER BY Name;

GO
--08.
CREATE VIEW V_EmployeesHiredAfter2000 AS (
	SELECT FirstName, LastName
	FROM Employees
	WHERE YEAR(HireDate) > 2000
);

GO
--09.
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5;

--10.
SELECT EmployeeID, 
	FirstName, 
	LastName, 
	Salary, 
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC;

--11.
SELECT * FROM (
	SELECT EmployeeID, 
		FirstName, 
		LastName, 
		Salary, 
		DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000 ) 
	AS Subquery
WHERE [Rank] = 2
ORDER BY Salary DESC;

--Part 2
USE Geography;
GO

--12.
SELECT CountryName AS [Country Name],
	IsoCode AS [ISO Code]
FROM Countries
WHERE LOWER(CountryName) LIKE '%a%a%a%'
ORDER BY IsoCode;

--13.
SELECT PeakName, 
	RiverName, 
	LOWER(CONCAT(LEFT(PeakName, LEN(PeakName) - 1), RiverName)) AS Mix
FROM Peaks, Rivers
WHERE RIGHT(LOWER(PeakName), 1) = LEFT(LOWER(RiverName), 1)
ORDER BY Mix;

--Part 3
USE Diablo;
GO

--14.
SELECT TOP(50) 
	Name, 
	FORMAT(Start, 'yyyy-MM-dd') AS Start
FROM Games
WHERE YEAR(Start) IN (2011, 2012)
ORDER BY Start, Name;

--15.
SELECT Username,
	RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider]
FROM Users
ORDER BY [Email Provider], Username;

--16.
SELECT Username, IpAddress AS [IP Address]
FROM Users
WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username;

--17.
SELECT Name AS Game,
	CASE
		WHEN DATEPART(HOUR, Start) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, Start) < 18 THEN 'Afternoon'
		ELSE 'Evening'
	END AS [Part of the Day],
	CASE
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration <= 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		ELSE 'Extra Long'
	END AS Duration
FROM Games
ORDER BY Name, Duration, [Part of the Day];

--Part 4
USE Orders;
GO

--18.
SELECT ProductName, 
	OrderDate,
	DATEADD(DAY, 3, OrderDate) AS [Pay Due],
	DATEADD(MONTH, 1, OrderDate) AS [Delivery Due]
FROM Orders;

--19.
CREATE DATABASE BuiltinFunctions;
GO
USE BuiltinFunctions;
GO

CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(20) NOT NULL,
	Birthdate DATETIME2 NOT NULL
);
GO

INSERT INTO People (Name, Birthdate)
VALUES
	('Victor', '2000-12-07 00:00:00.000'),
	('Steven', '1992-09-10 00:00:00.000'),
	('Stephen', '1910-09-19 00:00:00.000'),
	('John', '2010-01-06 00:00:00.000');

SELECT Name,
	DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],
	DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],
	DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
	DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
FROM People