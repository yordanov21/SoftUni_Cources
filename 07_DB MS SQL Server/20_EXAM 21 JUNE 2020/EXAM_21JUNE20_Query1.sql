CREATE DATABASE TripService

USE [TripService]

--1 DDL----------------------------------------------------------------------------
CREATE TABLE Cities(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(15,2)
)

CREATE TABLE Rooms(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(15,2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
	BookDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	ReturnDate DATE NOT NULL,
	CancelDate DATE,
	CHECK(BookDate<ArrivalDate AND ArrivalDate<ReturnDate)
)

CREATE TABLE Accounts(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	BirthDate DATE NOT NULL,
	Email VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE AccountsTrips(
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	TripId INT FOREIGN KEY REFERENCES Trips(Id) NOT NULL,
	Luggage INT CHECK(Luggage>=0)  NOT NULL 
	PRIMARY KEY(AccountId, TripId)
)

--2 INSERT----------------------------------------------------------------------------
INSERT INTO Accounts(FirstName, MiddleName,LastName, CityId,BirthDate,Email)
VALUES ('John','Smith','Smith',34,'1975-07-21','j_smith@gmail.com'),
       ('Gosho',NULL,'Petrov',11,'1978-05-16','g_petrov@gmail.com'),
       ('Ivan','Petrovich','Pavlov',59,'1849-09-26','i_pavlov@softuni.bg'),
       ('Friedrich','Wilhelm','Nietzsche',2,'1844-10-15','f_nietzsche@softuni.bg')

INSERT INTO Trips(RoomId, BookDate,ArrivalDate,ReturnDate,CancelDate)
	VALUES (101,'2015-04-12','2015-04-14','2015-04-20','2015-02-02'),
           (102,'2015-07-07','2015-07-15','2015-07-22','2015-04-29'),
           (103,'2013-07-17','2013-07-23','2013-07-24',NULL),
           (104,'2012-03-17','2012-03-31','2012-04-01','2012-01-10'),
           (109,'2017-08-07','2017-08-28','2017-08-29',NULL)

--3 UPDATE----------------------------------------------------------------------------
UPDATE Rooms
SET Price+=0.14*Price
WHERE HotelId IN(5,7,9)

--4 DELETE----------------------------------------------------------------------------
DELETE FROM Accounts
WHERE Id=47

DELETE FROM Trips
WHERE Id IN(
			SELECT TripId FROM AccountsTrips
			WHERE AccountId=47	
			)

DELETE FROM AccountsTrips
WHERE AccountId=47

--QUERIES------------------------------------------------------------------------------------------------------
--5-----------------------------------------------------------------------------------
SELECT a.FirstName,
		a.LastName,
		FORMAT( a.BirthDate,'MM-dd-yyyy') AS [BirtDate],
		c.[Name] AS [Hometown],
		a.Email 
FROM Accounts AS a
JOIN Cities AS c ON c.Id=a.CityId
WHERE Email LIKE 'e%'
ORDER BY c.[Name] ASC

--6---------------------------------------------------------------------------------
SELECT c.[Name] AS [City], COUNT(h.Id) AS [Hotels] FROM Cities AS c
JOIN Hotels AS h ON h.CityId=c.Id
GROUP BY c.Name
ORDER BY COUNT(h.Id) DESC

--7---------------------------------------------------------------------------------
SELECT acct.AccountId, 
	   CONCAT(a.FirstName, a.LastName) AS [FullName],
	   MAX(DATEDIFF(DAY,t.ArrivalDate, t.ReturnDate)) AS [LongestTrip],
	   MIN(DATEDIFF(DAY,t.ArrivalDate, t.ReturnDate)) AS [ShortestTrip]
FROM AccountsTrips AS acct
JOIN Trips AS t ON t.Id=acct.TripId
JOIN Accounts AS a ON a.Id=acct.AccountId
WHERE A.MiddleName IS NULL AND t.CancelDate IS NULL
GROUP BY acct.AccountId, a.FirstName, a.LastName
ORDER BY MAX(DATEDIFF(DAY,t.ArrivalDate, t.ReturnDate)) DESC, 
		 MIN(DATEDIFF(DAY,t.ArrivalDate, t.ReturnDate)) ASC

--8--------------------------------------------------------------------------------
SELECT TOP(10) c.Id,c.[Name] AS [City], 
			   c.CountryCode AS [Country], 
			   COUNT(a.CityId) AS [Accounts] 
FROM Cities AS c
JOIN Accounts AS a ON a.CityId=c.Id
GROUP BY c.Id, c.Name,c.CountryCode
ORDER BY  COUNT(a.CityId) DESC

--9--------------------------------------------------------------------------------
SELECT a.Id, 
	   a.Email, 
	   c.[Name] AS [City],
	   COUNT(t.Id) AS [Trips] 
FROM Accounts AS a
JOIN Cities AS c ON c.Id=a.CityId
JOIN Hotels AS h ON h.CityId=c.Id
JOIN AccountsTrips AS acct ON acct.AccountId=a.Id
JOIN Trips AS t ON t.Id=acct.TripId
JOIN Rooms AS r ON r.Id=t.RoomId
WHERE r.HotelId=h.Id
GROUP BY a.Id, a.Email ,c.Name
ORDER BY  COUNT(t.Id) DESC, a.Id ASC

--10-----------------------------------------------------------------------------
SELECT 
		t.Id, 
		CONCAT(a.FirstName,' ',a.MiddleName,' ', a.LastName) AS [FullName],
		c.[Name] AS [From], 
		(SELECT TOP(1) c.Name FROM Trips AS tr
		JOIN Rooms AS r ON r.Id=tr.RoomId
		JOIN Hotels AS h ON h.Id=r.HotelId
		JOIN Cities AS c ON c.Id=h.CityId
		WHERE tr.Id=t.Id
		) AS [To],
		(
		CASE
			 WHEN t.CancelDate IS NOT NULL THEN 'Canseled'
			 ELSE CONCAT(DATEDIFF(DAY,t.ArrivalDate, t.ReturnDate),' days')
	    END
		) AS [Duration]
FROM AccountsTrips AS acct
JOIN Accounts AS a ON a.Id=acct.AccountId
JOIN Cities AS c ON c.Id=a.CityId
JOIN Trips AS t ON t.Id=acct.TripId
JOIN Rooms AS r ON r.Id=t.RoomId
JOIN Hotels AS h ON h.Id=r.HotelId
ORDER BY [FullName], t.Id

--11---------------------------------------------------------------------------------
GO

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT , @Date DATE, @People INT)
RETURNS VARCHAR(200)
AS
BEGIN
	DECLARE @roomId int =(
								SELECT top(1) r.Id from Rooms as r
								JOIN Hotels AS h on h.Id=r.HotelId
								join Trips as t on t.RoomId=r.Id
								WHERE (@Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate)
									  AND t.CancelDate IS NULL
									  AND r.HotelId=@HotelId
									  AND R.Beds>@People
								ORDER by r.Price desc
								)
	IF(@roomId IS NULL)
	BEGIN
	RETURN 'No rooms available'
	END

	DECLARE @roomType varchar(50)=( 
						SELECT TOP(1) r.Type from Rooms as r
						JOIN Hotels AS h on h.Id=r.HotelId
						join Trips as t on t.RoomId=r.Id
						WHERE (@Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate)
						AND t.CancelDate IS NULL
						AND r.HotelId=@HotelId
						AND R.Beds>@People
						ORDER by r.Price desc
						)
	
	DECLARE @roomBeds INT=( 
						SELECT TOP(1) r.Beds from Rooms as r
						JOIN Hotels AS h on h.Id=r.HotelId
						join Trips as t on t.RoomId=r.Id
						WHERE (@Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate)
						AND t.CancelDate IS NULL
						AND r.HotelId=@HotelId
						AND R.Beds>@People
						ORDER by r.Price desc
						)

	DECLARE @roomPrice decimal(15,2)=( 
						SELECT TOP(1) r.Price from Rooms as r
						JOIN Hotels AS h on h.Id=r.HotelId
						join Trips as t on t.RoomId=r.Id
						WHERE (@Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate)
						AND t.CancelDate IS NULL
						AND r.HotelId=@HotelId
						AND R.Beds>@People
						ORDER by r.Price desc
						)

	DECLARE @hotelRate decimal(15,2)=( 
						SELECT TOP(1) h.BaseRate from Rooms as r
						JOIN Hotels AS h on h.Id=r.HotelId
						join Trips as t on t.RoomId=r.Id
						WHERE (@Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate)
						AND t.CancelDate IS NULL
						AND r.HotelId=@HotelId
						AND R.Beds>@People
						ORDER by r.Price desc
						)
declare @totalPrice decimal(15,2)=( @hotelRate+@roomPrice)*@People
RETURN CONCAT('Room ', @roomId, ': ', @roomType,' (',@roomBeds,' beds) - $',@totalPrice)
END

GO

--ZA PROVERKA NA 11------------------------------------------------------------------------
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)
SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
-------------------------------------------------------------------------------------------

--12---------------------------------------------------------------------------------------
GO

CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN
	DECLARE @targetRoomHotelId int=(
									SELECT h.Id FROM Hotels AS h
									JOIN Rooms AS r ON r.HotelId=h.Id
									WHERE r.Id=@TargetRoomId
									)
	DECLARE @currentRoomHotelId int=(
									SELECT r.HotelId FROM Trips AS t
									JOIN Rooms AS r ON r.Id=t.RoomId									
									WHERE t.Id=@TripId
									)
	IF(@targetRoomHotelId!=@currentRoomHotelId)
	BEGIN
		;THROW 50000,'Target room is in another hotel!',1;
	END

	DECLARE @targetBeds int =(
								SELECT r.Beds FROM Hotels AS h
								JOIN Rooms AS r ON r.HotelId=h.Id
								WHERE r.Id=@TripId
								)
	DECLARE @currentBeds int=(
									SELECT r.Beds FROM Trips AS t
									JOIN Rooms AS r ON r.Id=t.RoomId									
									WHERE t.Id=@TargetRoomId
								)
	IF(@currentBeds<@targetBeds)
	BEGIN 
		;THROW 50001,'Not enough beds in target room!',1;
	END
	ELSE
	BEGIN
	UPDATE Trips
	SET RoomId=@TargetRoomId
	WHERE Id=@TripId
	END
END

GO

--ZA PROVERKA NA 12-----------------------------------------------------------------------------------
EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10

EXEC usp_SwitchRoom 10, 7
EXEC usp_SwitchRoom 10, 8
------------------------------------------------------------------------------------------------------