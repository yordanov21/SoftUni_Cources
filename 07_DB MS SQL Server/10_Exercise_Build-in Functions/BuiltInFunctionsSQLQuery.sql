USE [SoftUni]

--PROBLEM 1
SELECT FirstName,LastName FROM Employees
	WHERE SUBSTRING(FirstName, 1,2)='SA'

SELECT FirstName,LastName FROM Employees
	WHERE LEFT(FirstName, 2)='SA'

SELECT FirstName,LastName FROM Employees
	WHERE FirstName LIKE 'SA%'

--PROBLEM 2
SELECT FirstName,LastName FROM Employees
	WHERE LastName LIKE '%ei%'

--PROBLEM 3
SELECT FirstName FROM Employees
	WHERE  DepartmentID IN (3,10) AND
	CAST(DATEPART (YEAR, HireDate) AS INT) BETWEEN 1995 AND 2005 

--PROBLEM 4
SELECT FirstName, LastName FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--PROBLEM 5
SELECT [Name] FROM Towns
WHERE LEN([Name])=5 OR LEN([Name])=6
ORDER BY [Name] ASC

--PROBLEM 6
SELECT TownID, [Name] FROM Towns
WHERE [Name] LIKE '[MKBE]%' 
ORDER BY [Name] ASC

--PROBLEM 7
SELECT TownID, [Name] FROM Towns
WHERE [Name] LIKE '[^RBD]%' 
ORDER BY [Name] ASC

--PROBLEM 8
CREATE VIEW V_EmployeesHiredAfter2000 AS 
SELECT FirstName, LastName FROM Employees
WHERE CAST(DATEPART (YEAR, HireDate) AS INT) > 2000 

SELECT * FROM V_EmployeesHiredAfter2000

--PROBLEM 9
SELECT FirstName, LastName FROM Employees
WHERE LEN(LastName)=5

--PROBLEM 10
SELECT EmployeeID, FirstName, LastName, Salary, DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees
		WHERE Salary BETWEEN 10000 AND 50000
		ORDER BY Salary DESC

--PROBMEN 11
SELECT * FROM (SELECT EmployeeID, FirstName, LastName, Salary, DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees
		WHERE Salary BETWEEN 10000 AND 50000 )AS temp
	WHERE temp.[Rank]=2
	ORDER BY temp.Salary DESC


--PROBLEM 12
USE [Geography]

SELECT CountryName, IsoCode FROM Countries
	WHERE CountryName LIKE '%a%a%a%'
	ORDER BY IsoCode ASC

--PROBLEM 13
SELECT p.PeakName, r.RiverName, LOWER(CONCAT(LEFT(p.PeakName, LEN(p.PeakName)-1), r.RiverName)) AS [Mix]
FROM Peaks AS p, Rivers AS r
	WHERE RIGHT(p.PeakName,1)= LEFT(r.RiverName,1)
	ORDER BY Mix ASC

-- reshena s JOIN
SELECT p.PeakName, r.RiverName, LOWER(CONCAT(LEFT(p.PeakName, LEN(p.PeakName)-1), r.RiverName)) AS [Mix] FROM Peaks AS p
JOIN Rivers AS r ON RIGHT(p.PeakName,1)= LEFT(r.RiverName,1)
	ORDER BY Mix ASC

--PROBLEM 14
USE [Diablo]

SELECT TOP 50 [Name], FORMAT([Start],'yyyy-MM-dd') AS [Start] FROM Games
WHERE CAST(DATEPART (YEAR, [Start]) AS INT) BETWEEN 2011 AND 2012 
ORDER BY [Start], [Name]

--PROBLEM 15
SELECT Username, RIGHT(Email,LEN(Email)- CHARINDEX('@',Email)) AS EmailProvider FROM Users
ORDER BY EmailProvider ASC, Username ASC

--PROBLEM 16
SELECT Username, IpAddress FROM Users
	WHERE IpAddress LIKE '[0-9][0-9][0-9].1%.[0-9][0-9][0-9]'
ORDER BY Username ASC


SELECT Username, IpAddress FROM Users
	WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username ASC

--PROBLEM 17
SELECT [Name] AS [Game],
CASE 
	WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
	WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
	ELSE 'Evening'
END AS [Part of the day],
CASE 
	WHEN Duration <=3 THEN 'Extra Short'
	WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
	WHEN Duration >6 THEN 'Long'
	ELSE 'Extra Long'
END AS [Duration]
FROM Games
ORDER BY [Game] ASC, [Duration],[Part of the day]

--PROBLEM 18
USE [OnlineStore]
SELECT * FROM Orders