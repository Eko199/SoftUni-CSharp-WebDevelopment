--Part 1
USE Gringotts;
GO

--01.
SELECT COUNT(*) FROM WizzardDeposits;

--02.
SELECT MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits

--03.
SELECT DepositGroup,
	MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup;

--04.
SELECT TOP(2) DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize);

--05.
SELECT DepositGroup,
	SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup;

--06.
SELECT DepositGroup,
	SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup;

--07.
SELECT DepositGroup,
	SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC;

--08.
SELECT DepositGroup, 
	MagicWandCreator, 
	MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup;

--09.
SELECT AgeGroup, COUNT(*) AS WizardCount
FROM (
	SELECT 
		CASE
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		END AS AgeGroup
	FROM WizzardDeposits
) AS AgeGroupSubquery
GROUP BY AgeGroup;

--10.
SELECT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1);

--11.
SELECT DepositGroup,
	IsDepositExpired,
	AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired;

--12.
SELECT SUM([Difference])
FROM (
	SELECT DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id) 
		AS [Difference]
	FROM WizzardDeposits
) AS DifferencesSubquery;

--Part 2
GO
USE SoftUni;
GO

--13.
SELECT DepartmentID, SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID;

--14.
SELECT DepartmentID, MIN(Salary) AS MinimumSalary
FROM Employees
WHERE DepartmentID IN (2, 5, 7) 
AND HireDate > '2000-01-01'
GROUP BY DepartmentID;

--15.
SELECT *
INTO EmployeesWhoEarnMoreThan30000
FROM Employees
WHERE Salary > 30000;

DELETE FROM EmployeesWhoEarnMoreThan30000
WHERE ManagerID = 42;

UPDATE EmployeesWhoEarnMoreThan30000
SET Salary += 5000
WHERE DepartmentID = 1;

SELECT DepartmentID, AVG(Salary) AS AverageSalary
FROM EmployeesWhoEarnMoreThan30000
GROUP BY DepartmentID;

--16.
SELECT DepartmentID, MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000;

--17.
SELECT COUNT(Salary)
FROM Employees
WHERE ManagerID IS NULL;

--18.
SELECT DISTINCT 
	DepartmentID
	, Salary AS ThirdHighestSalary
FROM (
	SELECT DepartmentID,
		Salary,
		DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC)
		AS SalaryRank
	FROM Employees
) AS SalaryRankSubquery
WHERE SalaryRank = 3;

--19.
SELECT TOP(10) FirstName, LastName, DepartmentID
FROM Employees AS e
WHERE Salary > (
	SELECT AVG(Salary)
	FROM Employees AS eSub
	WHERE eSub.DepartmentID = e.DepartmentID
)
ORDER BY DepartmentID;