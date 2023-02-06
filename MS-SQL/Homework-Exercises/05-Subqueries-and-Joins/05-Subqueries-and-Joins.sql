--Part 1
USE SoftUni;
GO

--01.
SELECT TOP(5) EmployeeID, JobTitle, e.AddressID, AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY a.AddressID;

--02.
SELECT TOP(50) FirstName, LastName, t.Name AS Town, AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY FirstName, LastName;

--03.
SELECT EmployeeID, FirstName, LastName, d.Name AS DepartmentName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY EmployeeID;

--04.
SELECT TOP(5) EmployeeID, FirstName, Salary, d.Name AS DepartmentName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE Salary > 15000
ORDER BY e.DepartmentID;

--05.
SELECT TOP(3) e.EmployeeID, FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ProjectID IS NULL
ORDER BY e.EmployeeID;

--06.
SELECT FirstName, LastName, HireDate, d.Name AS DeptName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE HireDate > '1999-01-01'
AND d.Name IN ('Sales', 'Finance')
ORDER BY HireDate;

--07.
SELECT TOP(5) e.EmployeeID, FirstName, p.Name AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID;

--08.
SELECT e.EmployeeID,
	FirstName,
	CASE
		WHEN YEAR(p.StartDate) >= 2005 THEN NULL
		ELSE p.Name
	END AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24;

--09.
SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName AS ManagerName
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID;

--10.
SELECT TOP(50) 
	e.EmployeeID,
	CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
	CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName,
	d.Name AS DepartmentName
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID;

--11.
SELECT MIN(AverageSalary) AS MinAverageSalary
FROM (
	SELECT d.Name, AVG(Salary) AS AverageSalary
	FROM Departments AS d
	LEFT JOIN Employees AS e ON d.DepartmentID = e.DepartmentID
	GROUP BY d.Name
) AS AverageSalaries;

--Part 2
USE Geography;
GO

--12.
SELECT c.CountryCode, MountainRange, PeakName, Elevation
FROM Peaks AS p
JOIN Mountains AS m ON p.MountainId = m.Id
JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
JOIN Countries AS c ON mc.CountryCode = c.CountryCode
WHERE CountryName = 'Bulgaria' AND Elevation > 2835
ORDER BY Elevation DESC;

--13.
SELECT mc.CountryCode, COUNT(*) AS MountainRanges
FROM MountainsCountries AS mc
JOIN Countries AS c ON mc.CountryCode = c.CountryCode
WHERE c.CountryName IN ('United States', 'Russia', 'Bulgaria')
GROUP BY mc.CountryCode;

--14.
SELECT TOP(5) CountryName, RiverName
FROM Countries AS c
JOIN Continents AS cc ON c.ContinentCode = cc.ContinentCode
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE ContinentName = 'Africa'
ORDER BY CountryName;

--15.
SELECT ContinentCode, CurrencyCode, CurrencyUsage
FROM (
	SELECT c.ContinentCode, 
		CurrencyCode, 
		COUNT(*) AS CurrencyUsage,
		RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(*) DESC)
			AS CurrencyRank
	FROM Continents AS c
	JOIN Countries AS cc ON c.ContinentCode = cc.ContinentCode
	GROUP BY c.ContinentCode, CurrencyCode
	HAVING COUNT(*) <> 1
) AS Subquery
WHERE CurrencyRank = 1;

--16
SELECT COUNT(*)
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
WHERE mc.MountainId IS NULL;

--17.
SELECT TOP(5)
	CountryName, 
	MAX(Elevation) AS HighestPeakElevation,
	MAX(r.Length) AS LongestRiverLength
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks As p ON m.Id = p.MountainId
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
GROUP BY CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName;

--18.
SELECT TOP(5)
	CountryName AS Country,
	ISNULL(PeakName, '(no highest peak)') AS [Highest Peak Name],
	ISNULL(Elevation, 0) AS [Highest Peak Elevation],
	ISNULL(MountainRange, '(no mountain)') AS Mountain
FROM (
	SELECT CountryName, 
		PeakName,
		Elevation,
		MountainRange,
		RANK() OVER (PARTITION BY CountryName ORDER BY Elevation DESC)
			AS PeakRank
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
	LEFT JOIN Peaks As p ON m.Id = p.MountainId
) AS PeaksSubquery
WHERE PeakRank = 1
ORDER BY CountryName, [Highest Peak Name];