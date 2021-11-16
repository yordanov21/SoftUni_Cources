CREATE DATABASE School

USE [School]
--1 DDL--
CREATE TABLE Students(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	MiddleName VARCHAR(25),
	LastName VARCHAR(30) NOT NULL,
	Age INT CHECK(Age>=5 AND Age<=100),
	[Address] VARCHAR(50),
	Phone CHAR(10)
)

CREATE TABLE Subjects(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20) NOT NULL,
	Lessons INT CHECK(Lessons>0) NOT NULL
)

CREATE TABLE StudentsSubjects(
	Id INT PRIMARY KEY IDENTITY,
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
	Grade DECIMAL(4,2) CHECK(Grade BETWEEN 2 AND 6)
)

CREATE TABLE Exams(
	Id INT PRIMARY KEY IDENTITY,
	[Date] DATETIME2,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsExams(
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	ExamId INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL,
	Grade DECIMAL(4,2) CHECK(Grade BETWEEN 2 AND 6)
	PRIMARY KEY(StudentId,ExamId)
)

CREATE TABLE Teachers(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	[Address] VARCHAR(20) NOT NULL,
	Phone CHAR(10),
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers(
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL,
	PRIMARY KEY(StudentId,TeacherId)
)

--2 INSERT--
INSERT INTO Teachers(FirstName, LastName,[Address],Phone,SubjectId)
	VALUES('Ruthanne', 'Bamb', '84948 Mesta Junction', 3105500146, 6),
		  ('Gerrard', 'Lowin', '370 Talisman Plaza', 3324874824, 2),
		  ('Merrile', 'Lambdin', '81 Dahle Plaza', 4373065154, 5),
		  ('Bert', 'Ivie', '2 Gateway Circle', 4409584510, 4)

INSERT INTO Subjects([Name],Lessons)
	VALUES('Geometry',12),
		  ('Health',10),
		  ('Drama',7),
		  ('Sports',9)

--3 UPDATE--
UPDATE StudentsSubjects
SET Grade=6.00
WHERE (SubjectId=1 OR SubjectId=2) AND Grade>=5.50

--4 DELETE--
DELETE FROM StudentsTeachers
WHERE TeacherId IN(
					SELECT Id FROM Teachers 
					WHERE Phone LIKE '%72%'
)

DELETE FROM Teachers 
WHERE Phone LIKE '%72%'

--5 Teen Students 
SELECT FirstName, LastName, Age FROM Students
WHERE Age>=12
ORDER BY FirstName ASC, LastName ASC

--6--
SELECT s.FirstName, s.LastName,  COUNT(TeacherId) AS [TeachersCount] FROM Students AS s
JOIN StudentsTeachers AS st ON s.Id=st.StudentId
GROUP BY st.StudentId, s.FirstName, s.LastName
ORDER BY LastName

--7 --
SELECT CONCAT(s.FirstName,' ',s.LastName) AS [Full Name] FROM Students AS s
LEFT JOIN StudentsExams AS se ON se.StudentId=s.Id
LEFT JOIN Exams AS e ON e.Id=se.ExamId
WHERE se.Grade IS NULL
ORDER BY [Full Name]

--8-
SELECT TOP(10) s.FirstName, s.LastName, ROUND(CAST(AVG(se.Grade) AS DECIMAL(4,2)),2)AS [Grade] FROM Students AS s
LEFT JOIN StudentsExams AS se ON se.StudentId=s.Id
LEFT JOIN Exams AS e ON e.Id=se.ExamId
GROUP BY se.StudentId, s.FirstName, s.LastName
ORDER BY AVG(se.Grade) DESC, s.FirstName ASC , s.LastName ASC

--9--
SELECT CONCAT(FirstName,' ',ISNULL(MiddleName+' ','')+ LastName) AS [Full Name] FROM Students AS s
full JOIN StudentsSubjects AS ss ON ss.StudentId=s.Id
full JOIN Subjects AS sub ON sub.Id=ss.SubjectId
WHERE sub.[Name] IS NULL
ORDER BY [Full Name]

--10--
SELECT s.[Name], AVG(ss.Grade) AS [AverageGrade] FROM Subjects AS s
JOIN StudentsSubjects AS ss ON ss.SubjectId=s.Id
GROUP BY s.Id, s.Name
ORDER BY s.Id ASC


--11--
GO

CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(4,2))
RETURNS VARCHAR(80)
AS
BEGIN
	DECLARE @checkedStudentId INT =(
									SELECT TOP(1) s.Id  FROM Students AS s
									WHERE @studentId=s.Id
									)
	IF(@checkedStudentId IS NULL)
	BEGIN 
		RETURN 'The student with provided id does not exist in the school!';
	END

	IF(@grade>6.0)
	BEGIN
		RETURN 'Grade cannot be above 6.00!'
	END

	DECLARE @count INT =(  --MOJE I BEZ CONVERT-A, DAVASHE GRESHKA AKO CONKATENIRANE S + ZARADI INT-A)
						SELECT  CONVERT(INT,COUNT(ExamId)) FROM StudentsExams
						WHERE Grade BETWEEN @grade AND (@grade+0.5) AND StudentId=@studentId
						GROUP BY StudentId
						)

	DECLARE @studentFirstName VARCHAR(30)=(
								SELECT FirstName FROM Students
								WHERE Id=@studentId
							)
							
	RETURN CONCAT('You have to update ',@count ,' grades for the student ',@studentFirstName)
END

GO

SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)
SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)
SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)

--12--

GO

CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	DECLARE @checkedStudentId INT =(
									SELECT TOP(1) s.Id  FROM Students AS s
									WHERE @studentId=s.Id
									)
 IF(@checkedStudentId IS NULL)
 BEGIN 
 DECLARE @errorMessage VARCHAR(70)='This school has no student with the provided id!';
	THROW 50001,@errorMessage,1
 END
 ELSE
 BEGIN
	DELETE FROM StudentsTeachers
	WHERE StudentId IN(
					SELECT Id FROM Students
					WHERE Id=@StudentId
				  )
	DELETE FROM StudentsSubjects
	WHERE StudentId IN(
					SELECT Id FROM Students
					WHERE Id=@StudentId
				  )
	DELETE FROM StudentsExams
	WHERE StudentId IN(
					SELECT Id FROM Students
					WHERE Id=@StudentId
				  )

	DELETE FROM Students
	WHERE Id=@StudentId
END
END

GO

EXEC usp_ExcludeFromSchool 301