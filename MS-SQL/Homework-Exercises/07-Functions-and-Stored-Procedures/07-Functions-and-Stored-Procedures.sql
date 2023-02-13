--Part 1
USE SoftUni;
GO

--01.
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName AS [First Name]
		, LastName AS [Last Name]
	FROM Employees
	WHERE Salary > 35000;
END
GO

--02.
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @salary DECIMAL(18, 4)
AS
BEGIN
	SELECT FirstName AS [First Name]
		, LastName AS [Last Name]
	FROM Employees
	WHERE Salary >= @salary;
END
GO

--03.
CREATE PROCEDURE usp_GetTownsStartingWith @start VARCHAR(10)
AS
BEGIN
	SELECT [Name] AS Town
	FROM Towns
	WHERE LOWER([Name]) LIKE CONCAT(@start, '%');
END
GO

--04.
CREATE PROCEDURE usp_GetEmployeesFromTown @town VARCHAR(50)
AS
BEGIN
	SELECT FirstName AS [First Name]
		, LastName AS [Last Name] 
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON a.TownID = t.TownID
	WHERE t.[Name] = @town;
END
GO

--05.
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18, 4))
RETURNS VARCHAR(7) AS
BEGIN
	IF @salary < 30000
		RETURN 'Low';

	IF @salary <= 50000
		RETURN 'Average';

	RETURN 'High';
END
GO

--06.
CREATE PROCEDURE usp_EmployeesBySalaryLevel @salaryLevel VARCHAR(7)
AS
BEGIN
	SELECT FirstName AS [First Name]
		, LastName AS [Last Name] 
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel;
END
GO

--07.
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(20), @word VARCHAR(50))
RETURNS BIT AS
BEGIN
	DECLARE @wordIndex INT = 1;
	SET @setOfLetters = LOWER(@setOfLetters);
	SET @word = LOWER(@word);
	
	WHILE @wordIndex <= LEN(@word)
	BEGIN
		IF CHARINDEX(SUBSTRING(@word, @wordIndex, 1), @setOfLetters) = 0
			RETURN 0;

		SET @wordIndex += 1;
	END

	RETURN 1;
END
GO

--08.
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment @departmentId INT
AS
BEGIN
	DECLARE @employeesToBeDeletedIds TABLE(Id INT NOT NULL);

	INSERT INTO @employeesToBeDeletedIds
	SELECT EmployeeID 
	FROM Employees
	WHERE DepartmentID = @departmentId;

	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN 
		(SELECT * FROM @employeesToBeDeletedIds);

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT;

	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN 
		(SELECT * FROM @employeesToBeDeletedIds);

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN 
		(SELECT * FROM @employeesToBeDeletedIds);

	DELETE FROM Employees
	WHERE EmployeeID IN 
		(SELECT * FROM @employeesToBeDeletedIds);

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId;

	SELECT COUNT(*)
	FROM Employees
	WHERE DepartmentID = @departmentId;
END
GO

--Part 2
USE Bank;
GO

--09.
CREATE PROCEDURE usp_GetHoldersFullName
AS
BEGIN
	SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
	FROM AccountHolders;
END
GO

--10.
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan @balance MONEY
AS
BEGIN
	SELECT FirstName AS [First Name]
		, LastName AS [Last Name] 
	FROM AccountHolders AS ah
	WHERE @balance < (
		SELECT SUM(Balance)
		FROM Accounts AS a
		WHERE ah.Id = a.AccountHolderId
	)
	ORDER BY [First Name], [Last Name];
END
GO

--11.
CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18, 4), @yearlyInterest FLOAT, @years INT)
RETURNS DECIMAL(18, 4) AS
BEGIN
	RETURN @sum * POWER(1 + @yearlyInterest, @years);
END
GO

--12.
CREATE PROCEDURE usp_CalculateFutureValueForAccount @accountId INT, @yearlyInterest FLOAT
AS
BEGIN
	SELECT 
		ah.Id AS [Account Id]
		, FirstName AS [First Name]
		, LastName AS [Last Name]
		, Balance AS [Current Balance]
		, dbo.ufn_CalculateFutureValue(Balance, @yearlyInterest, 5)
	FROM Accounts AS a
	JOIN AccountHolders AS ah ON ah.Id = a.AccountHolderId
	WHERE a.Id = @accountId;
END
GO

--Part 3
USE Diablo;
GO

--13.
CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(50))
RETURNS TABLE 
AS
RETURN (
	SELECT SUM(Cash) AS SumCash
	FROM (
		SELECT Cash,
			ROW_NUMBER() OVER(ORDER BY Cash DESC) AS RowNumber
		FROM UsersGames AS ug
		JOIN Games AS g ON ug.GameId = g.Id
		WHERE g.Name = @gameName
	) AS CashRowsSubquery
	WHERE RowNumber % 2 = 1
);
GO

SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist');