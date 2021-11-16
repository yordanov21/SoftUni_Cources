CREATE DATABASE Hotel

USE Hotel

-- PROBLEM 15
CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(100) NOT NULL,
	Notes NVARCHAR (MAX)
)

INSERT INTO Employees(FirstName,LastName,Title,Notes)
	VALUES
		('Velizar', 'Velikov', 'Receptionist', 'Nice customer'),
		('Ivan', 'Ivanov', 'Concierge', 'Nice one'),
		('Elisaveta', 'Bagriana', 'Cleaner', 'Poetesa')

CREATE TABLE Customers(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	AccountNumber INT NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber	VARCHAR(15) NOT NULL,
	EmergencyName NVARCHAR(50),
	EmergencyNumber VARCHAR(15),
	Notes NVARCHAR(500)
)	

INSERT INTO Customers
VALUES
(123456789, 'Ginka', 'Shikerova', '359888777888', 'Sistry mi', '7708315342', 'Kinky'),
(123480933, 'Chaika', 'Stavreva', '359888777888', 'Sistry mi', '7708315342', 'Lawer'),
(123454432, 'Mladen', 'Isaev', '359888777888', 'Sistry mi', '7708315342', 'Wants a call girl')

CREATE TABLE RoomStatus(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	RoomStatus BIT NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus(RoomStatus, Notes)
VALUES
(1,'Refill the minibar'),
(2,'Check the towels'),
(3,'Move the bed for couple')

CREATE TABLE RoomTypes(
	RoomType VARCHAR(20) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(500)
)

INSERT INTO RoomTypes (RoomType, Notes)
VALUES
('Suite', 'Two beds'),
('Wedding suite', 'One king size bed'),
('Apartment', 'Up to 3 adults and 2 children')

CREATE TABLE BedTypes(
	BedType VARCHAR(20) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(500)
)

INSERT INTO BedTypes
VALUES
('Double', 'One adult and one child'),
('King size', 'Two adults'),
('Couch', 'One child')

CREATE TABLE Rooms(
	RoomNumber INT PRIMARY KEY NOT NULL,
	RoomType VARCHAR(20) FOREIGN KEY REFERENCES RoomTypes(RoomType),
	BedType VARCHAR(20) FOREIGN KEY REFERENCES BedTypes(BedType),
	Rate INT,
	RoomStatus NVARCHAR(50),
	Notes NVARCHAR(MAX)
)

INSERT INTO Rooms (RoomNumber, Notes)
VALUES
(12,'Free'),
(15, 'Free'),
(23, 'Clean it')

CREATE TABLE Payments(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	PaymentDate DATE NOT NULL,
	AccountNumber INT,
	FirstDateOccupied DATE,
	LastDateOccupied DATE,
	TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied),
	AmountCharged DECIMAL(14,2),
	TaxRate DECIMAL(8, 2),
	TaxAmount DECIMAL(8, 2),
	PaymentTotal DECIMAL(15, 2),
	Notes VARCHAR(MAX)
)

INSERT INTO Payments (EmployeeId, PaymentDate, AmountCharged)
VALUES
(1, '12/12/2018', 2000.40),
(2, '12/12/2018', 1500.40),
(3, '12/12/2018', 1000.40)

CREATE TABLE Occupancies(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	DateOccupied DATE NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
	RateApplied INT,
	PhoneCharge INT,
	Notes NVARCHAR(500)
)

INSERT INTO Occupancies (EmployeeId,DateOccupied,AccountNumber, RateApplied, Notes) 
	VALUES
(1,'12/12/2018',10, 55.55, 'too'),
(2,'12/12/2018',11, 15.55, 'much'),
(3,'12/12/2018',12, 35.55, 'typing')


--PROBLEM 23

UPDATE Payments
	SET TaxRate-=TaxRate*0.03

SELECT TaxRate FROM Payments

--PROBLEM 24
TRUNCATE TABLE Occupancies