--Section 1. DDL
CREATE DATABASE Boardgames;
GO
USE Boardgames;
GO

--01.
CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
);

CREATE TABLE Addresses (
	Id INT PRIMARY KEY IDENTITY,
	StreetName NVARCHAR(100) NOT NULL,
	StreetNumber INT NOT NULL,
	Town VARCHAR(30) NOT NULL,
	Country VARCHAR(50) NOT NULL,
	ZIP INT NOT NULL
);

CREATE TABLE Publishers (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) UNIQUE NOT NULL,
	AddressId INT NOT NULL FOREIGN KEY REFERENCES Addresses(Id),
	Website NVARCHAR(40),
	Phone NVARCHAR(20)
);

CREATE TABLE PlayersRanges (
	Id INT PRIMARY KEY IDENTITY,
	PlayersMin INT NOT NULL,
	PlayersMax INT NOT NULL
);

CREATE TABLE Boardgames (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	YearPublished INT NOT NULL,
	Rating DECIMAL(3, 2) NOT NULL,
	CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
	PublisherId INT NOT NULL FOREIGN KEY REFERENCES Publishers(Id),
	PlayersRangeId INT NOT NULL FOREIGN KEY REFERENCES PlayersRanges(Id)
);

CREATE TABLE Creators (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(30) NOT NULL
);

CREATE TABLE CreatorsBoardgames (
	CreatorId INT NOT NULL FOREIGN KEY REFERENCES Creators(Id),
	BoardgameId INT NOT NULL FOREIGN KEY REFERENCES Boardgames(Id),
	PRIMARY KEY(CreatorId, BoardgameId)
);

--Section 2. DML
--02.
INSERT INTO Boardgames
VALUES
	('Deep Blue', 2019, 5.67, 1, 15, 7),
	('Paris', 2016, 9.78, 7, 1, 5),
	('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
	('Bleeding Kansas', 2020, 3.25, 3, 7, 4),
	('One Small Step', 2019, 5.75, 5, 9, 2);

INSERT INTO Publishers
VALUES
	('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
	('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
	('BattleBooks', 13, 'www.battlebooks.com', '+12345678907');

--03.
UPDATE PlayersRanges
SET PlayersMax += 1
WHERE PlayersMin = 2
AND PlayersMax = 2;

UPDATE Boardgames
SET Name = CONCAT(Name, 'V2')
WHERE YearPublished >= 2020;

--04.
SELECT Id
INTO #AddressesToDeleteIds
FROM Addresses 
WHERE Country IN (
	SELECT DISTINCT Country
	FROM Addresses
	WHERE Town LIKE 'L%'
);

DELETE CreatorsBoardgames
FROM CreatorsBoardgames AS cb
JOIN Boardgames AS b ON cb.BoardgameId = b.Id
JOIN Publishers AS p ON b.PublisherId = p.Id
WHERE AddressId IN (SELECT * FROM #AddressesToDeleteIds);

DELETE Boardgames
FROM Boardgames AS b
JOIN Publishers AS p ON b.PublisherId = p.Id
WHERE AddressId IN (SELECT * FROM #AddressesToDeleteIds);

DELETE FROM Publishers
WHERE AddressId IN (SELECT * FROM #AddressesToDeleteIds);

DELETE FROM Addresses
WHERE Id IN (SELECT * FROM #AddressesToDeleteIds);

--Secton 3. Querying
--05.
SELECT Name, Rating
FROM Boardgames
ORDER BY YearPublished, Name DESC;

--06.
SELECT b.Id, b.Name, YearPublished, c.Name AS CategoryName
FROM Boardgames AS b
JOIN Categories AS c ON b.CategoryId = c.Id
WHERE c.Name IN ('Strategy Games', 'Wargames')
ORDER BY YearPublished DESC;

--07.
SELECT c.Id, CONCAT(FirstName, ' ', LastName) AS CreatorName, Email
FROM Creators AS c
LEFT JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
WHERE BoardgameId IS NULL;

--08.
SELECT TOP(5) 
	b.Name, Rating, c.Name AS CategoryName
FROM Boardgames AS b
JOIN Categories AS c ON b.CategoryId = c.Id
JOIN PlayersRanges AS p ON b.PlayersRangeId = p.Id
WHERE (Rating > 7.00 AND b.Name LIKE '%a%')
OR (Rating > 7.50 AND PlayersMin = 2 AND PlayersMax = 5)
ORDER BY b.Name, Rating DESC;

--09.
SELECT CONCAT(FirstName, ' ', LastName) AS FullName, Email, Rating
FROM (
	SELECT FirstName
		,LastName
		,Email
		,Rating
		,RANK() OVER(PARTITION BY c.Id ORDER BY Rating DESC) AS RatingRank
	FROM Creators AS c
	JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
	JOIN Boardgames AS b ON cb.BoardgameId = b.Id
	WHERE Email LIKE '%.com'
) AS RatingsRankSubquery
WHERE RatingRank = 1
ORDER BY FullName;

--10.
SELECT LastName
	,CEILING(AVG(Rating)) AS AverageRating
	,p.Name AS PublisherName
FROM Creators AS c
JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
JOIN Boardgames AS b ON cb.BoardgameId = b.Id
JOIN Publishers AS p ON b.PublisherId = p.Id
WHERE p.Name = 'Stonemaier Games'
GROUP BY c.Id, c.LastName, p.Name
ORDER BY AVG(Rating) DESC;

--Section 4. Programmability
--11.
GO
CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
RETURNS INT AS
BEGIN
	RETURN (
		SELECT COUNT(*)
		FROM Creators AS c
		JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
		JOIN Boardgames AS b ON cb.BoardgameId = b.Id
		WHERE FirstName = @name
	);
END
GO

--12.
CREATE PROC usp_SearchByCategory @category VARCHAR(50)
AS
BEGIN
	SELECT
		b.Name
		,YearPublished
		,Rating
		,c.Name AS CategoryName
		,p.Name AS PublisherName
		,CONCAT(PlayersMin, ' people') AS MinPlayers
		,CONCAT(PlayersMax, ' people') AS MaxPlayers
	FROM Boardgames AS b
	JOIN Categories AS c ON b.CategoryId = c.Id
	JOIN Publishers AS p ON b.PublisherId = p.Id
	JOIN PlayersRanges AS pr ON b.PlayersRangeId = pr.Id
	WHERE c.Name = @category
	ORDER BY PublisherName, YearPublished DESC;
END