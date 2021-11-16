CREATE DATABASE [Service]

USE [Service]


--1 DDL--
CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL UNIQUE,
	[Password] VARCHAR(50) NOT NULL, 
	[Name] VARCHAR(50),
	Birthdate DATETIME2,
	Age INT CHECK(Age BETWEEN 14 AND 110),
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME2,
	Age INT CHECK(Age BETWEEN 18 AND 110),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status](
	Id INT PRIMARY KEY IDENTITY,
	Label VARCHAR(50) NOT NULL
)

CREATE TABLE Reports(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT FOREIGN KEY REFERENCES  Categories(Id) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES  [Status](Id) NOT NULL,
	OpenDate DATETIME2 NOT NULL,
	CloseDate DATETIME2,
	[Description] VARCHAR(200) NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

--2 INSERT--
INSERT INTO Employees(FirstName, LastName, Birthdate, DepartmentId)
	VALUES('Marlo', 'O''Malley','1958-9-21',1),
	      ('Niki', 'Stanaghan','1969-11-26',4),
		  ('Ayrton', 'Senna','1960-03-21',9),
		  ('Ronnie', 'Peterson','1944-02-14',9),
		  ('Giovanna', 'Amati','1959-07-20',5)

INSERT INTO Reports(CategoryId,StatusId,OpenDate, CloseDate,[Description],UserId,EmployeeId)
	VALUES(1,1,'2017-04-13',NULL,'Stuck Road on Str.133',6,2),
	      (6,3,'2015-09-05','2015-12-06','Charity trail running',3,5),
		  (14,2,'2015-09-07',NULL,'Falling bricks on Str.58',5,2),
		  (4,3,'2017-07-03','2017-07-06','Cut off streetlight on Str.11',1,1)

--3 UPDATE--
UPDATE Reports
SET CloseDate=GETDATE()
WHERE CloseDate IS NULL

--4 DELETE--
DELETE FROM Reports
WHERE StatusId=4

--Querying--
--5--
SELECT [Description],  FORMAT (OpenDate, 'dd-MM-yyyy') AS OpenDate FROM Reports AS r
WHERE EmployeeId IS NULL
ORDER BY r.OpenDate ASC, [Description] ASC

--6--
SELECT r.Description, c.Name FROM Reports AS r
JOIN Categories AS c ON c.Id=r.CategoryId
ORDER BY r.Description ASC, c.Name ASC

--7--
SELECT TOP(5) c.[Name] AS [CategoryName], COUNT(r.Id) AS [ReportsNumber] FROM Reports AS r
JOIN Categories AS c ON c.Id=r.CategoryId
GROUP BY r.CategoryId, c.Name
ORDER BY COUNT(r.Id) DESC, c.[Name] ASC

--8--
SELECT u.Username, c.Name AS [CategoryName] FROM Users AS u 
JOIN Reports AS r ON u.Id=r.UserId
JOIN Categories AS c ON c.Id=r.CategoryId
WHERE DATEPART(MONTH, r.OpenDate)=DATEPART(MONTH, u.Birthdate) and DATEPART(DAY, r.OpenDate)=DATEPART(DAY, u.Birthdate)
ORDER BY u.Username ASC, c.[Name] ASC

--9--
SELECT e.FirstName+' '+e.LastName AS [FullName], count(u.Id) AS [UserCount] FROM Employees AS e
LEFT JOIN Reports AS r ON r.EmployeeId=e.Id
LEFT JOIN Users AS u ON u.Id=r.UserId
GROUP BY  e.FirstName, e.LastName
ORDER BY count(u.Id) DESC, [FullName]ASC

--10--
SELECT 
		ISNULL(e.FirstName+ ' '+ e.LastName, 'None') AS [Employee], 
		ISNULL(d.Name, 'None') AS [Department],
		ISNULL(c.Name, 'None') AS [Category],
		r.Description AS [Description],
		FORMAT (r.OpenDate, 'dd.MM.yyyy' )AS [OpenDate],
		s.Label AS [Status],
		u.Name AS [User]		
FROM Reports AS r
LEFT JOIN Employees AS e ON e.Id=r.EmployeeId
LEFT JOIN Departments AS d ON d.Id=e.DepartmentId
LEFT JOIN Categories AS c ON c.Id=r.CategoryId
LEFT JOIN Users AS u ON u.Id=r.UserId
LEFT JOIN Status as s ON s.Id= r.StatusId
--GROUP BY e.FirstName+ ' '+ e.LastName,d.Name, c.Name, r.Description, r.OpenDate, s.Label, u.Username
ORDER BY e.FirstName DESC,
		e.LastName DESC, 
		[Department] ASC,
		[Category] ASC,
		[Description] ASC,
		[OpenDate] ASC,
		[Status] ASC, 
		[User] ASC

--11--
GO

CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME) 
RETURNS INT
AS
BEGIN
	IF(@StartDate IS NULL OR @EndDate IS NULL)
	BEGIN
		RETURN 0
	END

	DECLARE @hours INT=DATEDIFF(HOUR,@StartDate,@EndDate)
	RETURN @hours
END

GO

--12--
GO
	
CREATE PROC usp_AssignEmployeeToReport(@EmployeeId int, @ReportId int) 
AS
BEGIN
	DECLARE @EmployeeDepartmentId int=(
										SELECT DepartmentId from Employees 
										WHERE Id=@EmployeeId
									  )
	DECLARE @ReportDepartmentId int=(
									SELECT c.DepartmentId FROM Reports AS r
									JOIN Categories AS c ON c.Id=r.CategoryId
									WHERE r.Id=@ReportId
									)

	IF(@EmployeeDepartmentId!=@ReportDepartmentId)
		THROW 50000,'Employee doesn''t belong to the appropriate department!',1;


	UPDATE Reports SET EmployeeId=@EmployeeId
	WHERE Id=@ReportId 
END
GO

EXEC usp_AssignEmployeeToReport 30, 1