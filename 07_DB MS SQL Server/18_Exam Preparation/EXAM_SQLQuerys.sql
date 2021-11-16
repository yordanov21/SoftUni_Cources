CREATE DATABASE Airport

USE [Airport]

--1 DDL--
CREATE TABLE Planes(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
)

CREATE TABLE Flights(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME2,
	ArrivalTime DATETIME2,
	Origin VARCHAR(50) NOT NULL,
	Destination VARCHAR(50) NOT NULL,
	PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] VARCHAR(30) NOT NULL,
	PassportId CHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(30) NOT NULL
)

CREATE TABLE Luggages(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets(
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	FlightId INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
	LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
	Price DECIMAL(15,2) NOT NULL
)

--2 INSERT--
INSERT INTO Planes([Name],Seats,[Range])
	VALUES('Airbus 336', 112,5132),
		  ('Airbus 330', 432,5325),
		  ('Boeing 369', 231,2355),
		  ('Stelt 297', 254,2143),
		  ('Boeing 338', 165,5111),
		  ('Airbus 558', 387,1342),
		  ('Boeing 128', 345,5541)


INSERT INTO LuggageTypes([Type])
	VALUES ('Crossbody Bag'),
	       ('School Backpack'),
	       ('Shoulder Bag')

--3 UPDATE--	
UPDATE Tickets
SET Price+=Price*0.13
WHERE FlightId IN (
					SELECT Id FROM Flights
					WHERE Destination = 'Carlsbad'
				  )

--4 DELETE--
DELETE FROM Tickets
WHERE FlightId IN (
					SELECT Id FROM Flights
					WHERE Destination='Ayn Halagim'
				  )
DELETE FROM Flights
WHERE Destination='Ayn Halagim'

--5--
SELECT * FROM Planes
WHERE [Name] LIKE '%tr%'
ORDER BY Id,[Name], Seats, [Range]

--6--
SELECT FlightId,SUM(Price) FROM Tickets
GROUP BY FlightId
ORDER BY SUM(Price) DESC, FlightId ASC

--7--
SELECT p.FirstName+ ' ' +p.LastName AS [Full Name],
	   f.Origin,
	   f.Destination 
	   FROM Tickets AS t
JOIN Passengers AS p ON p.Id=t.PassengerId
JOIN Flights AS f ON f.Id=t.FlightId
ORDER BY [Full Name], f.Origin, f.Destination

--8--
SELECT p.FirstName, p.LastName, p.Age FROM Passengers AS p
LEFT JOIN Tickets AS t ON t.PassengerId=p.Id
WHERE t.Id IS NULL
ORDER BY p.Age DESC, p.FirstName ASC, p.LastName ASC

--9--
SELECT CONCAT(p.FirstName,' ',p.LastName) AS [Full Name],
	   pl.[Name] AS [Plane Name],
	   CONCAT(f.Origin,' - ', f.Destination) AS [Trip],
	   lt.[Type] AS [Luggage Type]
FROM Passengers AS p
JOIN Tickets AS t ON t.PassengerId=p.Id
JOIN Flights AS f ON f.Id=t.FlightId
JOIN Planes AS pl ON pl.Id=f.PlaneId
JOIN Luggages AS l ON l.Id=t.LuggageId
JOIN LuggageTypes AS lt ON lt.Id=l.LuggageTypeId
ORDER BY [Full Name] ASC, [Plane Name] ASC, f.Origin ASC, f.Destination ASC, [Luggage Type] ASC

--10--
SELECT pl.[Name], pl.Seats, COUNT(t.PassengerId) AS [Passengers Count] FROM Planes AS pl
LEFT JOIN Flights AS f ON  pl.Id=f.PlaneId
LEFT JOIN Tickets AS t ON f.Id=t.FlightId
GROUP BY pl.[Name], pl.Seats
ORDER BY COUNT(t.PassengerId) DESC, pl.[Name] ASC, pl.Seats ASC

--11 FUNCTION--
GO

CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT) 
RETURNS VARCHAR(70)
AS
BEGIN 
	IF(@peopleCount<=0)
	BEGIN
		RETURN 'Invalid people count!';
	END

	DECLARE @flightId INT =(
							SELECT TOP(1) f.Id FROM Flights AS f
							WHERE @origin=f.Origin AND @destination=f.Destination
							)

	IF(@flightId IS NULL)
	BEGIN
		RETURN 'Invalid flight!';
	END

	DECLARE @ticketPrice DECIMAL(15,2)=(
										SELECT TOP(1) t.Price FROM Flights AS f
										JOIN Tickets AS t ON f.Id=t.FlightId
											WHERE @origin=f.Origin AND @destination=f.Destination
										)
	DECLARE @totalPrice DECIMAL(24,2) = @ticketPrice*@peopleCount;

	RETURN CONCAT('Total price ', @totalPrice);
END

GO
--check the function--
SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)
SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)
SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)

--12--
GO

CREATE PROC usp_CancelFlights
AS
BEGIN
	UPDATE Flights
	SET DepartureTime=NULL, ArrivalTime=NULL
	WHERE DATEDIFF(SECOND,ArrivalTime,DepartureTime)<0
END

GO

EXEC usp_CancelFlights