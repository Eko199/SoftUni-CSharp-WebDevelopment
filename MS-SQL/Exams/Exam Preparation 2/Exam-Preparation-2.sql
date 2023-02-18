--Section 1. DDL
CREATE DATABASE Airport;
GO
USE Airport;
GO

--01.
CREATE TABLE Passengers (
	Id INT PRIMARY KEY IDENTITY,
	FullName VARCHAR(100) UNIQUE NOT NULL,
	Email VARCHAR(50) UNIQUE NOT NULL
);

CREATE TABLE Pilots (
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) UNIQUE NOT NULL,
	LastName VARCHAR(30) UNIQUE NOT NULL,
	Age TINYINT NOT NULL CHECK(Age BETWEEN 21 AND 62),
	Rating FLOAT CHECK(Rating BETWEEN 0.0 AND 10.0)
);

CREATE TABLE AircraftTypes (
	Id INT PRIMARY KEY IDENTITY,
	TypeName VARCHAR(30) UNIQUE NOT NULL
);

CREATE TABLE Aircraft (
	Id INT PRIMARY KEY IDENTITY,
	Manufacturer VARCHAR(25) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	Year INT NOT NULL,
	FlightHours INT,
	Condition CHAR NOT NULL,
	TypeId INT NOT NULL FOREIGN KEY REFERENCES AircraftTypes(Id)
);

CREATE TABLE PilotsAircraft (
	AircraftId INT NOT NULL FOREIGN KEY REFERENCES Aircraft(Id),
	PilotId INT NOT NULL FOREIGN KEY REFERENCES Pilots(Id),
	PRIMARY KEY(AircraftId, PilotId)
);

CREATE TABLE Airports (
	Id INT PRIMARY KEY IDENTITY,
	AirportName VARCHAR(70) UNIQUE NOT NULL,
	Country VARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE FlightDestinations (
	Id INT PRIMARY KEY IDENTITY,
	AirportId INT NOT NULL FOREIGN KEY REFERENCES Airports(Id),
	Start DATETIME NOT NULL,
	AircraftId INT NOT NULL FOREIGN KEY REFERENCES Aircraft(Id),
	PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id),
	TicketPrice DECIMAL(18, 2) NOT NULL DEFAULT 15
);

--Section 2. DML
--02.
INSERT INTO Passengers
SELECT CONCAT(FirstName, ' ', LastName), 
	CONCAT(FirstName, LastName, '@gmail.com')
FROM Pilots
WHERE Id BETWEEN 5 AND 15;

--03.
UPDATE Aircraft
SET Condition = 'A'
WHERE Condition IN ('C', 'B')
AND (FlightHours IS NULL OR FlightHours <= 100)
AND Year >= 2013;

--04.
DELETE FROM Passengers
WHERE LEN(FullName) <= 10;

--Section 3. Querying
--05.
SELECT Manufacturer, Model, FlightHours, Condition
FROM Aircraft
ORDER BY FlightHours DESC;

--06.
SELECT FirstName, LastName, Manufacturer, Model, FlightHours
FROM PilotsAircraft AS pa
JOIN Pilots AS p ON pa.PilotId = p.Id
JOIN Aircraft AS a ON pa.AircraftId = a.Id
WHERE FlightHours <= 304
ORDER BY FlightHours DESC, FirstName;

--07.
SELECT TOP(20)
	d.Id AS DestinationId
	,Start
	,FullName
	,AirportName
	,TicketPrice
FROM FlightDestinations AS d
JOIN Airports AS a ON d.AirportId = a.Id
JOIN Passengers AS p ON d.PassengerId = p.Id
WHERE DAY(Start) % 2 = 0
ORDER BY TicketPrice DESC, AirportName;

--08.
SELECT AircraftId
	,Manufacturer
	,FlightHours
	,COUNT(*) AS FlightDestinationsCount
	,ROUND(AVG(TicketPrice), 2) AS AvgPrice
FROM Aircraft AS a
JOIN FlightDestinations AS fd ON a.Id = fd.AircraftId
GROUP BY AircraftId, Manufacturer, FlightHours
HAVING COUNT(*) >= 2
ORDER BY FlightDestinationsCount DESC, AircraftId;

--09.
SELECT FullName
	,COUNT(DISTINCT AircraftId) AS CountOfAircraft
	,SUM(TicketPrice) AS TotalPayed
FROM Passengers AS p
JOIN FlightDestinations AS d ON p.Id = d.PassengerId
WHERE SUBSTRING(FullName, 2, 1) = 'a'
GROUP BY FullName
HAVING COUNT(DISTINCT AircraftId) > 1
ORDER BY FullName;

--10.
SELECT AirportName
	, Start AS DayTime
	, TicketPrice
	, FullName
	, Manufacturer
	, Model
FROM FlightDestinations AS d
LEFT JOIN Airports AS ap ON d.AirportId = ap.Id
LEFT JOIN Passengers AS p ON d.PassengerId = p.Id
LEFT JOIN Aircraft AS ac ON d.AircraftId = ac.Id
WHERE CAST(Start AS TIME) BETWEEN '6:00' AND '20:00'
AND TicketPrice > 2500
ORDER BY Model;

--Section 4.
--11.
GO
CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT AS
BEGIN
	RETURN (
		SELECT COUNT(d.Id)
		FROM FlightDestinations AS d
		RIGHT JOIN Passengers AS p ON d.PassengerId = p.Id
		WHERE Email = @email
	);
END
GO

--12.
CREATE PROC usp_SearchByAirportName @airportName VARCHAR(70)
AS
BEGIN
	SELECT AirportName
		,FullName
		,CASE
			WHEN TicketPrice <= 400 THEN 'Low'
			WHEN TicketPrice > 1501 THEN 'High'
			ELSE 'Medium'
		END AS LevelOfTickerPrice
		,Manufacturer
		,Condition
		,TypeName
	FROM Airports as ap
	JOIN FlightDestinations AS d ON ap.Id = d.AirportId
	JOIN Passengers AS p ON d.PassengerId = p.Id
	JOIN Aircraft AS ac ON d.AircraftId = ac.Id
	JOIN AircraftTypes AS at ON ac.TypeId = at.Id
	WHERE AirportName = @airportName
	ORDER BY Manufacturer, FullName;
END