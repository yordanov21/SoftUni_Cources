
--1--
USE [SoftUni]
GO

CREATE PROC usp_GetEmployeesSalaryAbove35000 
AS
	SELECT FirstName, LastName,Salary FROM Employees
	WHERE Salary>35000
GO

--za judje bez 2 v imeto na PROC  
GO
CREATE PROC usp_GetEmployeesSalary2Above35000 
AS
	SELECT FirstName AS [First Name], LastName AS [Last Name]FROM Employees
	WHERE Salary>35000
GO

EXEC usp_GetEmployeesSalary2Above35000
--2--
GO
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@salary DECIMAL(18,4))
AS
	SELECT e.FirstName AS [First Name], e.LastName AS [Last Name]FROM Employees AS e
	WHERE e.Salary>=@salary
GO

EXEC usp_GetEmployeesSalaryAboveNumber 48100

--3--
GO
CREATE PROC usp_GetTownsStartingWith @startName VARCHAR(MAX)
AS
	SELECT [Name] AS [Town] FROM Towns
	WHERE SUBSTRING([Name],1,LEN(@startName)) = @startName
GO
EXEC usp_GetTownsStartingWith Sa

--4--
GO
CREATE PROC usp_GetEmployeesFromTown @town VARCHAR(MAX)
AS
BEGIN
	SELECT e.FirstName, e.LastName FROM Employees AS e
	JOIN Addresses AS a ON a.AddressID=e.AddressID
	JOIN Towns AS t ON t.TownID=a.TownID
	WHERE t.[Name]=@town
END
GO

EXEC usp_GetEmployeesFromTown Sofia
--5--
USE [SoftUni]

GO
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(7)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(7) = CASE
		WHEN @salary < 30000 THEN 'Low'
		WHEN @salary BETWEEN 30000 AND 50000 THEN 'Average'
		ELSE 'High'
	END 

	RETURN @salaryLevel
END
GO
--sus IF Konstrukcia
GO
CREATE FUNCTION ufn_GetSalaryLevel2(@salary DECIMAL(18,4))
RETURNS VARCHAR(7)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(7)
	IF(@salary<30000)
	BEGIN
		SET @salaryLevel='Low'
	END
	ELSE IF (@salary<=50000)
	BEGIN
		SET @salaryLevel='Average'
	END
	ELSE
	BEGIN
		SET @salaryLevel='High'
	END

	RETURN @salaryLevel
END
GO

SELECT Salary, dbo. ufn_GetSalaryLevel(Salary) AS [Salary Level] FROM Employees
SELECT Salary, dbo. ufn_GetSalaryLevel2(Salary) AS [Salary Level] FROM Employees
GO

--6--
CREATE PROC usp_EmployeesBySalaryLevel @salaryLevel VARCHAR(7)
AS
BEGIN
	SELECT e.FirstName, e.LastName 
	FROM Employees AS e
	WHERE dbo.ufn_GetSalaryLevel(e.Salary) = @salaryLevel 
END

EXEC dbo.usp_EmployeesBySalaryLevel 'High'

--7--
GO
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX)) 
RETURNS BIT
AS
BEGIN
	DECLARE @i INT=1;
	DECLARE @result BIT=1;

	WHILE(@i<=LEN(@word))
	BEGIN
		DECLARE @currChar CHAR=SUBSTRING(@word,@i,1);
		DECLARE @charIndex INT=CHARINDEX(@currChar,@setOfLetters)
		
		if(@charIndex=0)
		BEGIN 
		SET @result=0	
		END

		SET @i+=1
	END

	RETURN @result
END
GO

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')

--8--
GO
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT) 
AS
BEGIN
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
							SELECT EmployeeID from Employees
							WHERE DepartmentID=@departmentId
						)
	UPDATE Employees
	SET  ManagerID=NULL
	WHERE ManagerID IN (
							SELECT EmployeeID from Employees
							WHERE DepartmentID=@departmentId
						)
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT
	UPDATE Departments
	SET ManagerID=NULL
	WHERE ManagerID IN (
							SELECT EmployeeID from Employees
							WHERE DepartmentID=@departmentId
						)
	DELETE FROM Employees
	WHERE DepartmentID=@departmentId

	DELETE FROM Departments
	WHERE DepartmentID=@departmentId

	SELECT COUNT(*) FROM Employees
	WHERE DepartmentID=@departmentId
END
GO

--9--
USE [Bank]

GO

CREATE PROC usp_GetHoldersFullName
AS
BEGIN
SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name] FROM AccountHolders
END

GO

--10--
GO
CREATE PROC usp_GetHoldersWithBalanceHigherThan @searchedBalanse DECIMAL(18,4)
AS
BEGIN
	SELECT ach.FirstName AS [First Name], ach.LastName AS [Last Name] FROM AccountHolders AS ach
	JOIN Accounts AS ac ON ac.AccountHolderId=ach.Id	
	GROUP BY AccountHolderId, FirstName, LastName
	HAVING SUM(ac.Balance)> @searchedBalanse
	ORDER BY FirstName, LastName
END
GO

--11--
GO

CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18,4),@yearlyInterestRate FLOAT, @yearsCount INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	DECLARE @initialSum DECIMAL(18,4)
	SET @initialSum=@sum*(POWER(1+@yearlyInterestRate,@yearsCount))

	RETURN @initialSum
END
GO

SELECT dbo.ufn_CalculateFutureValue(1000,0.1,5)

--12--
GO
CREATE PROC usp_CalculateFutureValueForAccount (@acauntID INT, @interestRate FLOAT)
AS
BEGIN
	SELECT 
		ac.Id AS [Account Id],
		ach.FirstName AS [First Name],
		ach.LastName AS [Last Name],
		ac.Balance AS [Current Balance],
		dbo.ufn_CalculateFutureValue(ac.Balance,@interestRate,5) AS [Balance in 5 years]
	FROM AccountHolders AS ach
	JOIN Accounts AS ac ON ac.AccountHolderId=ach.Id
	WHERE ac.Id=@acauntID
END
GO

exec usp_CalculateFutureValueForAccount 1,0.1
