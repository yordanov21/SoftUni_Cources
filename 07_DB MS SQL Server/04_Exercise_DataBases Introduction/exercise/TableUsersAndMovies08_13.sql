--PROBLEM 8
CREATE TABLE Users(
	Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX) 
	CHECK(DATALENGTH(ProfilePicture)<=900*1024),
	LastLoginTime DATETIME2 NOT NULL,
	IsDeleted BIT NOT NULL
)

INSERT INTO Users(Username,[Password],LastLoginTime,IsDeleted)
	VALUES
	('PESHO1','123456','05.19.2020', 0),
	('PESHO2','1234567','05.19.2020', 1),
	('PESHO3','12345678','05.19.2020', 0),
	('PESHO4','123456789','05.19.2020', 1),
	('PESHO5','1234567890','05.19.2020', 0)

SELECT * FROM Users

--PROBLEM 9 (CHANGE PRIMARY KEY)
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07B79D1ED4

ALTER TABLE Users
ADD CONSTRAINT PK_Users_CompositeIdUsername
PRIMARY KEY (Id, Username)

--PROBLEM 10 (ADD CHECK CONSTRAINT)
ALTER TABLE Users
ADD CONSTRAINT CK_Users_PasswordLength
CHECK(LEN([Password])>=5)

INSERT INTO Users(Username,[Password],LastLoginTime,IsDeleted)
	VALUES
	('PESHO10','12345','05.19.2020', 0)

--PROBLEM 11 (SET DEFAULT VALUE OF A FIELD)
ALTER TABLE Users
	ADD CONSTRAINT DF_Users_LastLoginTime
	DEFAULT GETDATE() FOR LastLoginTime

INSERT INTO Users(Username,[Password],IsDeleted)
	VALUES
	('PESHONoTime','12345', 0)

SELECT * FROM Users

--PROBLEM 12
ALTER TABLE Users
DROP CONSTRAINT [PK_Users_CompositeIdUsername]

ALTER TABLE Users
ADD CONSTRAINT PK_Users_Id
PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_usernameLength
CHECK(LEN(Username)>=3)


--PROBLEM 13
CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DirectorName NVARCHAR(50),
	Notes NVARCHAR(500)
)

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	GenresName NVARCHAR(50),
	Notes NVARCHAR(500)
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName NVARCHAR(50),
	Notes NVARCHAR(500)
)

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Title NVARCHAR(100) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
	CopyrightYear INT NOT NULL,
	[Length] INT,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Rating TINYINT NOT NULL,
	Notes NVARCHAR(500)
)

INSERT INTO Directors([DirectorName], Notes)
	VALUES
		('Director1', 'Director notes'),
		('Director2', 'Director notes2'),
		('Director3', 'Director notes3'),
		('Director4', 'Director notes4'),
		('Director5', 'Director notes5')

INSERT INTO Genres(GenresName)
	VALUES
		('Action'),
		('Commedy'),
		('Animation'),
		('Drama'),
		('Triler')

INSERT INTO Categories(CategoryName)
	VALUES
		('Category1'),
		('Category2'),
		('Category3'),
		('Category4'),
		('Category5')

INSERT INTO Movies(Title,DirectorId,CopyrightYear,[Length],GenreId,CategoryId,Rating,Notes)
	VALUES
		('Matrix 1',5,1999,150,5,1,10,'best of the best'),
		('Matrix 2',4,2003,130,4,2,10,'best of the best2'),
		('Matrix 3',3,2003,125,3,3,10,'best of the best3'),
		('Ironman',2,2010,150,1,4,4,'bestsdfdf of the best'),
		('Matrix 1',1,1999,150,2,5,8,'best sdffof the best')
