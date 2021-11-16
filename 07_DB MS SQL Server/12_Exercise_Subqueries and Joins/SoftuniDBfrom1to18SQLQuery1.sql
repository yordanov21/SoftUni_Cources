USE SoftUni

--01--
SELECT TOP(5) e.EmployeeID, e.JobTitle, e.AddressID , a.AddressText FROM Employees AS e
	JOIN Addresses AS a
	ON e.AddressID=a.AddressID
		ORDER BY e.AddressID
		
--02--
SELECT TOP(50) e.FirstName, e.LastName,t.[Name] AS [Town], a.AddressText FROM Employees AS e
	JOIN Addresses AS a
	ON e.AddressID = a.AddressID
	JOIN Towns AS t
	ON a.TownID=t.TownID
		ORDER BY e.FirstName, e.LastName

--03--
SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name] AS [DepartmentName] FROM Employees AS e
	LEFT OUTER JOIN Departments AS d
	ON d.DepartmentID=e.DepartmentID
		WHERE e.DepartmentID=3
		ORDER BY e.EmployeeID

--04--
SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.[Name] AS [DepartmentName] FROM Employees AS e
	JOIN Departments AS d
	ON d.DepartmentID=e.DepartmentID
		WHERE e.Salary>15000
		ORDER BY e.DepartmentID

--05--
SELECT TOP(3) e.EmployeeID, e.FirstName FROM Employees AS e
LEFT OUTER JOIN EmployeesProjects AS ep
ON ep.EmployeeID=e.EmployeeID
WHERE ep.EmployeeID IS NULL

--06--
SELECT e.FirstName, e.LastName, e.HireDate, d.[Name] AS DeptName FROM Employees AS e
 JOIN Departments AS d
ON d.DepartmentID=e.DepartmentID
WHERE e.HireDate>'1.1.1999'
AND d.[Name]='Sales' OR d.[Name]='Finance' 
ORDER BY e.HireDate ASC

--07--
SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name] AS [ProjectName] 
	FROM Employees AS e
		JOIN EmployeesProjects AS ep
		ON ep.EmployeeID=e.EmployeeID
		JOIN Projects AS p
		ON p.ProjectID=ep.ProjectID 
		WHERE p.StartDate> '08.13.2002' AND P.EndDate IS NULL
		ORDER BY e.EmployeeID

--08--
SELECT  e.EmployeeID, e.FirstName, 
	CASE
		WHEN DATEPART(YEAR,P.StartDate)>=2005 THEN NULL
		ELSE p.[name]
	END
    AS [ProjectName] 
	FROM Employees AS e
		JOIN EmployeesProjects AS ep
		ON ep.EmployeeID=e.EmployeeID
		JOIN Projects AS p
		ON p.ProjectID=ep.ProjectID 
		WHERE ep.EmployeeID=24
		ORDER BY e.EmployeeID

--09--
SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName AS [ManagerName] FROM Employees AS e
JOIN Employees AS m
ON e.ManagerID=m.EmployeeID 
WHERE e.ManagerID=3 or e.ManagerID=7
ORDER BY e.EmployeeID

--10--
SELECT TOP(50) e1.EmployeeID,
	CONCAT(e1.FirstName,' ', e1.LastName) AS [EmployeeName],
	CONCAT(e2.FirstName,' ', e2.LastName) AS [ManagerName],
		d.[Name] AS [DepartmentName]
			FROM Employees AS e1
			JOIN Employees AS e2
			ON e1.ManagerID=e2.EmployeeID 
			JOIN Departments AS d
			ON e1.DepartmentID= d.DepartmentID
			ORDER BY e1.EmployeeID

--11--
SELECT  DepartmentID, AVG(Salary) AS[Average Salary] FROM Employees 
GROUP BY DepartmentID
ORDER BY [Average Salary] ASC

--FOR JUDJE--
SELECT TOP(1) AVG(Salary) AS[MinAverageSalary] FROM Employees 
	GROUP BY DepartmentID
	ORDER BY [MinAverageSalary] ASC

--with subquery
SELECT MIN([Average Salary]) AS [MinAverageSalary]
	FROM (
		SELECT DepartmentID, AVG(Salary) AS[Average Salary] 
		FROM Employees 
		GROUP BY DepartmentID
	) AS [AverageSalaryQuery]

--12--
USE [Geography]

SELECT mountCount.CountryCode, mount.MountainRange, pks.PeakName, pks.Elevation FROM Peaks AS pks
JOIN Mountains AS mount
ON pks.MountainId=mount.Id
JOIN MountainsCountries AS mountCount
ON mount.Id=mountCount.MountainId
WHERE mountCount.CountryCode='BG' AND pks.Elevation>2835
ORDER BY pks.Elevation DESC

--13--
SELECT CountryCode, COUNT(MountainId) AS [MountainRanges]
	FROM MountainsCountries
WHERE CountryCode IN ('US', 'RU', 'BG')
GROUP BY CountryCode

--14--
SELECT TOP(5) c.CountryName,r.RiverName FROM CountriesRivers AS cr
RIGHT JOIN Rivers AS r
ON r.Id=cr.RiverId
RIGHT JOIN Countries AS c
ON c.CountryCode=cr.CountryCode
WHERE c.ContinentCode ='AF'
ORDER BY c.CountryName ASC

--15--
SELECT ContinentCode, CurrencyCode, CurrencyUsage
			FROM (
				SELECT ContinentCode,
						CurrencyCode, 
						COUNT(*) AS [CurrencyUsage],
						DENSE_RANK() OVER
						(PARTITION BY  ContinentCode ORDER BY COUNT(*) DESC) AS [CurrencyRank]
					FROM Countries
					GROUP BY ContinentCode, CurrencyCode					
				) AS [CurencyCountQuery]
WHERE CurrencyUsage>1 AND CurrencyRank=1
ORDER BY ContinentCode ASC, CurrencyCode ASC
				
--16--
SELECT COUNT(c.CountryName) AS [Count] FROM Countries AS c
FULL JOIN MountainsCountries AS mc
ON c.CountryCode= mc.CountryCode
WHERE mc.CountryCode IS NULL


--17--
SELECT TOP(5)  country.CountryName,
		MAX(p.Elevation) AS [HighestPeakElevation], 
		MAX(r.Length) AS [LongestRiverLength]
		FROM Countries AS country
			FULL JOIN MountainsCountries AS mc
			ON country.CountryCode=mc.CountryCode
			FULL JOIN Mountains AS m
			ON mc.MountainId=m.Id
			FULL JOIN Peaks AS p
			ON p.MountainId=m.Id
			FULL JOIN CountriesRivers AS cr
			ON cr.CountryCode=country.CountryCode
			FULL JOIN Rivers AS r
			ON cr.RiverId=r.Id
				GROUP BY country.CountryName
				ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName ASC

--18--

SELECT TOP(5) Country,
		CASE
			WHEN PeakName IS NULL THEN '(no highest peak)'
			ELSE PeakName
		END AS [Highest Peak Name], 
		CASE 
			WHEN Elevation IS NULL THEN 0
			ELSE Elevation
		END AS [Highest Peak Elevation],
		CASE 
			WHEN MountainRange IS NULL THEN '(no mountain)'
			ELSE MountainRange
		END AS [Mountain]
	FROM( 
		   SELECT *,
			DENSE_RANK() OVER
			(PARTITION BY [Country] ORDER BY [Elevation] DESC) AS [PeakRank]
				FROM (
					SELECT CountryName AS [Country],
					   p.PeakName,
					   p.Elevation,
					   m.MountainRange
					FROM Countries AS c
				LEFT OUTER JOIN MountainsCountries AS mc
				ON c.CountryCode=mc.CountryCode
				LEFT OUTER JOIN Mountains AS m
				ON mc.MountainId=m.Id
				LEFT OUTER JOIN Peaks AS p
				ON p.MountainId= m.Id
				) AS [FullInfoQuery]
		) AS [PeakRankingsQuery]
WHERE [PeakRank]=1
ORDER BY Country ASC, [Highest Peak Name] ASC

