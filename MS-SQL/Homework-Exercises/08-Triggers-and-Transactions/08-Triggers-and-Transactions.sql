--Part 1
USE Bank;
GO

--01.
CREATE TABLE Logs (
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	OldSum MONEY,
	NewSum MONEY
);
GO

CREATE TRIGGER tr_LogAccountBalanceChange
ON Accounts FOR UPDATE
AS
BEGIN
	INSERT INTO Logs (AccountId, OldSum, NewSum)
	SELECT i.Id, d.Balance, i.Balance
	FROM inserted AS i
	JOIN deleted AS d ON i.Id = d.Id;
END

--02.
CREATE TABLE NotificationEmails (
	Id INT PRIMARY KEY IDENTITY, 
	Recipient INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL, 
	Subject VARCHAR(50), 
	Body VARCHAR(80)
);
GO

CREATE TRIGGER tr_NotifyEmailAfterLog
ON Logs FOR INSERT
AS
BEGIN
	INSERT INTO NotificationEmails (Recipient, Subject, Body)
	SELECT AccountId, 
		CONCAT('Balance change for account: ', AccountId),
		CONCAT('On ', GETDATE(), ' your balance was changed from ', OldSum, ' to ', NewSum , '.')
	FROM inserted;
END
GO

--03.
CREATE PROC usp_DepositMoney @accountId INT, @moneyAmount DECIMAL(18, 4)
AS
BEGIN
	BEGIN TRANSACTION;

	UPDATE Accounts
	SET Balance += @moneyAmount
	WHERE Id = @accountId;

	COMMIT TRANSACTION;
END
GO

--04.
CREATE PROC usp_WithdrawMoney  @accountId INT, @moneyAmount DECIMAL(18, 4)
AS
BEGIN
	BEGIN TRANSACTION;

	UPDATE Accounts
	SET Balance -= @moneyAmount
	WHERE Id = @accountId;

	COMMIT TRANSACTION;
END
GO

--05.
CREATE PROC usp_TransferMoney  @senderId INT, @receiverId INT, @amount DECIMAL(18, 4)
AS
BEGIN
	BEGIN TRANSACTION;

	EXEC usp_WithdrawMoney @senderId, @amount;
	EXEC usp_DepositMoney @receiverId, @amount;

	COMMIT;
END
GO

--Part 2
USE Diablo;
GO

--06.
CREATE TRIGGER tr_RestrictBuyingHigherLevelItems
ON UserGameItems INSTEAD OF INSERT
AS
BEGIN
	INSERT INTO UserGameItems
	SELECT i.ItemId, i.UserGameId
	FROM inserted AS i
	JOIN UsersGames AS ug ON i.UserGameId = ug.Id
	JOIN Items AS it ON i.ItemId = it.Id
	WHERE it.MinLevel <= ug.Level;
END
GO

CREATE PROC usp_BuyItemForUserGame @itemId INT, @userGameId INT
AS
BEGIN
	INSERT INTO UserGameItems
	VALUES (@itemId, @userGameId);

	DECLARE @userGameLevel INT = (SELECT Level FROM UsersGames WHERE Id = @userGameId);
	DECLARE @itemLevel INT = (SELECT MinLevel FROM Items WHERE Id = @itemId);

	IF @itemLevel <= @userGameLevel
	BEGIN
		UPDATE UsersGames
		SET Cash -= (SELECT TOP(1) Price FROM Items WHERE Id = @itemId)
		WHERE Id = @userGameId;
	END
END
GO

BEGIN TRANSACTION;

UPDATE UsersGames
SET Cash += 50000
FROM UsersGames AS ug
JOIN Users AS u ON ug.UserId = u.Id
JOIN Games AS g ON ug.GameId = g.Id
WHERE Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
AND g.Name = 'Bali';

DROP TABLE IF EXISTS #itemsToBuy;

SELECT *
INTO #itemsToBuy
FROM Items
WHERE Id BETWEEN 251 AND 299 OR Id BETWEEN 501 AND 539;

DROP TABLE IF EXISTS #usersItemsToBuy;

SELECT ug.Id AS UserGameId
	, i.Id AS ItemId
	, ROW_NUMBER() OVER(ORDER BY ug.Id, i.Id) AS RowNumber
INTO #usersItemsToBuy
FROM UsersGames AS ug
JOIN Users AS u ON ug.UserId = u.Id
JOIN Games AS g ON ug.GameId = g.Id
CROSS JOIN #itemsToBuy AS i
WHERE Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
AND g.Name = 'Bali';

DECLARE @rowIndex INT = (SELECT COUNT(*) FROM #usersItemsToBuy);

WHILE @rowIndex > 0
BEGIN
	DECLARE @itemId INT = (SELECT ItemId FROM #usersItemsToBuy WHERE RowNumber = @rowIndex);
	DECLARE @userGameId INT = (SELECT UserGameId FROM #usersItemsToBuy WHERE RowNumber = @rowIndex);

	EXEC usp_BuyItemForUserGame @itemId, @userGameId;
	SET @rowIndex -= 1;
END

SELECT Username, g.Name, Cash, i.Name AS [Item Name]
FROM UsersGames AS ug
JOIN Users AS u ON ug.UserId = u.Id
JOIN Games AS g ON ug.GameId = g.Id
LEFT JOIN UserGameItems AS ugi ON ug.Id = ugi.UserGameId
LEFT JOIN Items AS i ON ugi.ItemId = i.Id
WHERE Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
AND g.Name = 'Bali'
ORDER BY Username, i.Name;

ROLLBACK;

--07.
BEGIN TRANSACTION;

DROP TABLE IF EXISTS #itemsToBuy;

SELECT Id, ROW_NUMBER() OVER(ORDER BY Id) AS RowNumber
INTO #itemsToBuyStamat
FROM Items
WHERE MinLevel BETWEEN 11 AND 12 OR MinLevel BETWEEN 19 AND 21;

DECLARE @rowNumber INT = (SELECT COUNT(*) FROM #itemsToBuyStamat);
DECLARE @stamatUserGameId INT = (
	SELECT ug.Id 
	FROM UsersGames AS ug
	JOIN Users AS u ON ug.UserId = u.Id
	JOIN Games AS g ON ug.GameId = g.Id
	WHERE Username = 'Stamat' AND g.Name = 'Safflower'
);

WHILE @rowNumber > 0
BEGIN
	DECLARE @currentItemId INT = (SELECT Id FROM #itemsToBuyStamat WHERE RowNumber = @rowNumber);

	EXEC usp_BuyItemForUserGame @currentItemId, @stamatUserGameId;
	SET @rowNumber -= 1;
END

SELECT i.Name AS [Item Name]
FROM UserGameItems AS ui
JOIN Items AS i ON ui.ItemId = i.Id
WHERE UserGameId = @stamatUserGameId
ORDER BY [Item Name];

ROLLBACK;

--Part 3
USE SoftUni;
GO

--08.
CREATE PROC usp_AssignProject @emloyeeId INT, @projectID INT
AS
BEGIN
	BEGIN TRANSACTION;

	INSERT INTO EmployeesProjects 
	VALUES (@emloyeeId, @projectID);

	IF 3 < (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @emloyeeId)
	BEGIN
		RAISERROR('The employee has too many projects!', 16, 1);
	END

	COMMIT;
END
GO

--09.
CREATE TABLE Deleted_Employees (
	EmployeeId INT PRIMARY KEY IDENTITY, 
	FirstName VARCHAR(50) NOT NULL, 
	LastName VARCHAR(50) NOT NULL, 
	MiddleName VARCHAR(50), 
	JobTitle VARCHAR(50) NOT NULL, 
	DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Departments(DepartmentId), 
	Salary MONEY NOT NULL
);
GO

CREATE TRIGGER tr_DeleteEmployee
ON Employees FOR DELETE
AS
BEGIN
	INSERT INTO Deleted_Employees
	SELECT FirstName
		,LastName
		,MiddleName
		,JobTitle
		,DepartmentID
		,Salary
	FROM deleted;
END