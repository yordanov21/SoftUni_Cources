
CREATE DATABASE People

USE People

--PROBLEM 7
CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(200) NOT NULL,
Picture VARBINARY
	CHECK(DATALENGTH(Picture)<=2000*1024),
Height FLOAT(2),
[Weight] FLOAT(2),
Gender BIT NOT NULL,
Birthdate DATETIME NOT NULL,
Biography NVARCHAR(MAX)
)


INSERT INTO People([Name],Height,[Weight],Gender, Birthdate, Biography)
	VALUES
	('DANCHO1',1.965,1.8695,0,'02.27.1990','MY biography is......'),
	('DANCHO2',1.965,1.8695,1,'05.02.1990','MY biography is......'),
	('DANCHO3',1.965,1.8695,0,'12.02.1990','MY biography is......'),
	('DANCHO4',1.95,1.8,1,'02.02.1990','MY biography is......'),
	('DANCHO5',1.9,20.202551115515,0,'06.10.1990','MY biography is......')


SELECT * FROM People