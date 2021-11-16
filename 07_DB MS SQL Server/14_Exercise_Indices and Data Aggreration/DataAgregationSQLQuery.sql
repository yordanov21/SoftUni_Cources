USE [Gringotts]

--1--
SELECT COUNT(Id) AS [Count] FROM WizzardDeposits

--2--
SELECT TOP(1) MagicWandSize AS [LongestMagicWand] FROM WizzardDeposits
ORDER BY MagicWandSize DESC

--3--
SELECT DepositGroup, MAX(MagicWandSize) AS [LongestMagicWand] from WizzardDeposits
GROUP BY DepositGroup

--4--
SELECT TOP(2) DepositGroup FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG( MagicWandSize) ASC

--5--
SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum] FROM WizzardDeposits
GROUP BY DepositGroup

--6--
SELECT DepositGroup, 
	   TotalSum 
	   FROM (
			SELECT DepositGroup,  
				   SUM(DepositAmount) AS [TotalSum], 
				   MagicWandCreator   
				   FROM WizzardDeposits
			GROUP BY DepositGroup, MagicWandCreator
			HAVING MagicWandCreator='Ollivander family'
			) AS [DepositsOllivanderFamily]

--RESHENA S WHERE (WHERE SE SLAGA PREDI GROUP BY!!!)
SELECT DepositGroup,  
	   SUM(DepositAmount) AS [TotalSum] 
FROM WizzardDeposits
WHERE MagicWandCreator='Ollivander family'
GROUP BY DepositGroup
			
--7--
SELECT DepositGroup, 
	   TotalSum 
	   FROM (
			SELECT DepositGroup,  
				   SUM(DepositAmount) AS [TotalSum], 
				   MagicWandCreator   
				   FROM WizzardDeposits
			GROUP BY DepositGroup, MagicWandCreator
			HAVING MagicWandCreator='Ollivander family'
			) AS [DepositsOllivanderFamily]
WHERE TotalSum<150000
ORDER BY TotalSum DESC

--MOJE I PO TOZI NACHIN, TUK SA POKAZANI REDA NA IZPISVANE NA KLAUZITE
SELECT DepositGroup,  
SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
WHERE MagicWandCreator='Ollivander family'
GROUP BY DepositGroup, MagicWandCreator
HAVING  SUM(DepositAmount)<150000
ORDER BY TotalSum DESC

--8--
SELECT DepositGroup, MagicWandCreator,MIN(DepositCharge) FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

--9-- 
SELECT
		CASE
			WHEN Age <=10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		END AS AgeGroup, COUNT(FirstName) AS [WizardCount] FROM WizzardDeposits
GROUP BY (CASE
			WHEN Age <=10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		END)

--10--
SELECT* FROM (
			SELECT LEFT(FirstName, LEN(1)) AS [FirstLetter] FROM WizzardDeposits
			GROUP BY FirstName, DepositGroup
			HAVING DepositGroup='Troll Chest') AS [FirstLettersFilter]
GROUP BY FirstLetter

--11--
SELECT DepositGroup,
	   IsDepositExpired,
	   AVG(DepositInterest) AS[AverageInterest]
FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup, IsDepositExpired 
ORDER BY DepositGroup DESC, IsDepositExpired ASC

--12--

SELECT SUM([DIFFERENCE]) AS [SumDifference] 
FROM (
		SELECT FirstName AS [Host Wizard],
        DepositAmount AS [Host Wizard Depozit],
	    LEAD(FirstName) OVER(ORDER BY Id ASC) AS [Guest Wizard],
	    LEAD(DepositAmount) OVER(ORDER BY Id ASC) AS [Guest Wizard Deposit],
	    DepositAmount-LEAD(DepositAmount) OVER(ORDER BY Id ASC) AS [Difference]
	FROM WizzardDeposits) AS [LeadQuery]
WHERE [Guest Wizard] IS NOT NULL

--13--
USE [SoftUni]

SELECT DepartmentID, SUM(Salary) AS [TotalSalary] FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

--14--
SELECT DepartmentID, MIN(Salary) AS [MinimumSalary] FROM Employees
WHERE HireDate > '01/01/2000'
GROUP BY DepartmentID
HAVING DepartmentID=2 or DepartmentID=5 or DepartmentID=7

--15--

SELECT * INTO EmployeesAverageSalary FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesAverageSalary
WHERE ManagerID=42

UPDATE EmployeesAverageSalary
SET Salary+=5000
WHERE DepartmentID=1

SELECT DepartmentID, AVG(Salary) AS [AverageSalary] FROM EmployeesAverageSalary
GROUP BY DepartmentID

--16--
SELECT DepartmentID, MAX(Salary) AS [MaxSalary] FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary)<30000 OR MAX(Salary)>70000 

--17--
SELECT COUNT(FirstName) AS [Count] FROM Employees
WHERE ManagerID IS NULL

--18--
SELECT DepartmentId,
       Salary AS [ThirdHighestSalary] 
FROM (
SELECT DepartmentID,
	   Salary,
	   DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS [SalaryRank]
FROM Employees) AS [SalaryRankinQuery]
WHERE SalaryRank=3
GROUP BY DepartmentID,Salary

--19--
SELECT TOP(10) e1.FirstName, 
	   e1.LastName, 
	   e1.DepartmentID 
FROM Employees AS e1
WHERE e1.Salary > (
					SELECT AVG(Salary) AS [AverageSalary] 
					FROM Employees AS e2
					WHERE e2.DepartmentID = e1.DepartmentID
					GROUP BY DepartmentID
				  ) 
ORDER BY e1.DepartmentID


