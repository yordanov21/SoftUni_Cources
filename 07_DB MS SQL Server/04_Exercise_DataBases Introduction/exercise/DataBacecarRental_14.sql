--PROBLEM 14
CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName VARCHAR(50) NOT NULL,
	DailyRate SMALLINT,
	WeeklyRate SMALLINT,
	MonthlyRate SMALLINT,
	WeekendRate SMALLINT
)


CREATE TABLE Cars(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	PlateNumber VARCHAR(10) NOT NULL,
	Manufacturer VARCHAR(50) NOT NULL,
	Model VARCHAR(25) NOT NULL,
	CarYear SMALLINT NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Doors TINYINT NOT NULL,
	Picture VARBINARY(MAX) 
	CHECK(DATALENGTH(Picture)<=2000*1024),
	Condition VARCHAR(20),
	Available BIT NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(50),
	LastName VARCHAR(50),
	Title VARCHAR(50),
	Notes VARCHAR(500)
)

CREATE TABLE Customers(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DriverLicenceNumber CHAR(10),
	FullName VARCHAR(100),
	[Address] VARCHAR(200),
	City VARCHAR(50),
	ZIPCode INT,
	Notes VARCHAR(500)
)

CREATE TABLE RentalOrders(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
	TankLevel INT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate DATE ,
	EndDate DATE ,
	TotalDays INT ,
	RateApplied TINYINT,
	TaxRate INT,
	OrderStatus BIT,
	Notes VARCHAR(500)
)

INSERT INTO Categories([CategoryName])
	VALUES
		('CATEGORY1'),
		('CATEGORY2'),
		('CATEGORY3')

INSERT INTO Cars(PlateNumber,Manufacturer,Model,CarYear,CategoryId,Doors,Available)
	VALUES
		('KH2659BK', 'AUDI', 'A4', 2001,3,4,0),
		('CA3340MA', 'BMW', 'MODEL 3', 2002,2,4,0),
		('CA4959KK', 'RENAUT', 'CANGO', 1999,3,3,0)

INSERT INTO Employees(FirstName, LastName)
	VALUES
		('PESHO', 'Peshov'),
		('PESHO2', 'Peshov'),
		('PESHO3', 'Peshov')

INSERT INTO Customers(DriverLicenceNumber,FullName, [Address],City)
	VALUES
		('1234567891','IVAN IVANOV', 'ULICA 21-VI VEK', 'SOFIA'),
		('1234567892','IVAN IVANOV2', 'ULICA 21-VI VEK', 'SOFIA'),
		('1234567893','IVAN IVANOV2', 'ULICA 21-VI VEK', 'SOFIA')

INSERT INTO RentalOrders(EmployeeId,CustomerId,CarId,TankLevel,KilometrageStart,KilometrageEnd,TotalKilometrage, StartDate,EndDate,TotalDays, RateApplied,TaxRate,OrderStatus,Notes)
	VALUES
		(1,1,1,50,100,200000,50000,'12.20.2019','08.20.2020',150,5,3000.20,0,'SADSADASDSADASSA'),
		(1,1,1,50,100,200000,50000,'12.20.2019','08.21.2020',150,5,3000.20,0,'SADSADASDSADASSA'),
		(1,1,1,50,100,200000,50000,'12.20.2019','08.22.2020',150,5,3000.20,0,'SADSADASDSADASSA')

SELECT * FROM RentalOrders