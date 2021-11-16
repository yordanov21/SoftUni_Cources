--problem 1 ONE-TO-ONE-Relationship--
CREATE DATABASE EntityRelationsDemo

USE [EntityRelationsDemo]

CREATE TABLE Passports(
	PassportID INT PRIMARY KEY IDENTITY (101,1),
	PassportNumber CHAR(8) NOT NULL
)
--Á‡ ONE TO ONE RELATIONSHIP “–ﬂ¡¬¿ ƒ¿ »Ã¿Ã≈ UNIQUE —À≈ƒ –≈‘≈–≈Õ÷»ﬂ“¿
CREATE TABLE Persons(
	PersonID INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	Salary DECIMAL(7,2) NOT NULL,
	PassportID INT NOT NULL FOREIGN KEY REFERENCES Passports(PassportID) UNIQUE
)

INSERT INTO Passports(PassportNumber)
	VALUES
	('N34FG21B'),
	('K65LO4R7'),
	('ZE657QP2')

INSERT INTO Persons(FirstName,Salary,PassportID)
	VALUES 
	('Roberto', 43000,102),
	('Tom', 56100,103),
	('Yana', 60200,101)

--problem 2 ONE-TO-Many Relationship
CREATE TABLE Manufacturers(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	EstablishedOn DATE NOT NULL
)

CREATE TABLE Models(
	ModelID INT PRIMARY KEY IDENTITY (101,1),
	[Name] NVARCHAR(25) NOT NULL,
	ManufacturerID INT NOT NULL FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers([Name],EstablishedOn)
	VALUES
	('BMW','07/03/1916'),
	('Tesla','01/01/2003'),
	('Lada','01/05/1966')

INSERT INTO Models([Name],ManufacturerID)
	VALUES
	('X1',1),
	('i6',1),
	('Model S',2),
	('Model X',2),
	('Model 3',2),
	('Nova',3)

--problem 3 MANY-TO-MANY Relationship

CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY IDENTITY (101,1),
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams(
	StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT NOT NULL FOREIGN KEY REFERENCES Exams(ExamID),
	PRIMARY KEY(StudentID, ExamID)
)

INSERT INTO Students([Name])
	VALUES
	('Mila'),
	('Toni'),
	('Ron')

INSERT INTO Exams([Name])
	VALUES
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g')

INSERT INTO StudentsExams(StudentID,ExamID)
	VALUES
	(1,101),
	(1,102),
	(2,101),
	(3,103),
	(2,102),
	(2,103)

--SELECT * FROM StudentsExams

--problem 4 Self-Rederencing
CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY IDENTITY (101,1),
	[Name] NVARCHAR(50) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers([Name], ManagerID)
	VALUES
	('John',NULL),
	('Maya',106),
	('Silvia',106),
	('Ted',105),
	('Mark',101),
	('Greta',101)
