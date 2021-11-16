CREATE DATABASE WMS

USE [WMS]

--1 DDL----------------------------------------------------------------------------
CREATE TABLE Clients(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) NOT NULL
)

CREATE TABLE Mechanics(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE Models(
	ModelId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Jobs(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL,
	[Status] VARCHAR(11) DEFAULT 'Pending' NOT NULL,
	ClientId INT FOREIGN KEY REFERENCES  Clients(ClientId) NOT NULL,	
	IssueDate DATE NOT NULL,
	FinishDate DATE,
	MechanicId INT FOREIGN KEY REFERENCES  Mechanics(MechanicId),
	CHECK([Status] ='Pending' OR [Status] ='In Progress'  OR[Status] ='Finished' )
)

CREATE TABLE Orders(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE,
	Delivered BIT DEFAULT 0 NOT NULL
)

CREATE TABLE Vendors(
	VendorId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Parts(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	[Description] VARCHAR(255),
	Price DECIMAL(6,2) CHECK(Price>0 AND Price<10000),
	VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId) NOT NULL,
	StockQty INT DEFAULT 0 CHECK(StockQty>=0) NOT NULL
)

CREATE TABLE PartsNeeded(
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
	Quantity INT DEFAULT 1 CHECK(Quantity>=1),
	PRIMARY KEY(JobId, PartId)
)
CREATE TABLE OrderParts(
	OrderId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
	Quantity INT DEFAULT 1 CHECK(Quantity>=1),
	PRIMARY KEY(OrderId, PartId)
)


--2 Insert--
INSERT INTO Clients(FirstName,LastName,Phone)
	VALUES  ('Teri','Ennaco','570-889-5187'),
			('Merlyn','Lawler','201-588-7810'),
			('Georgene','Montezuma','925-615-5185'),
			('Jettie','Mconnell','908-802-3564'),
			('Lemuel','Latzke','631-748-6479'),
			('Melodie','Knipp','805-690-1682'),
			('Candida','Corbley','908-275-8357')

INSERT INTO Parts(SerialNumber,Description,Price,VendorId)
	VALUES  ('WP8182119','Door Boot Seal',117.86,2),
			('W10780048','Suspension Rod',42.81,1),
			('W10841140','Silicone Adhesive', 6.77,4),
			('WPY055980','High Temperature Adhesive',13.94,3)

--3 Update
UPDATE Jobs
SET ModelId=3,Status='In Progress'
WHERE Status='Pending' and ModelId=3 


select * from Jobs
WHERE Status='Pending' OR Status='In Progress'
--4 Delete
DELETE FROM OrderParts
WHERE OrderId IN(
				SELECT OrderId FROM Orders
				WHERE OrderId=19
				)
DELETE FROM Orders
WHERE OrderId=19

--Query
--5
SELECT CONCAT(m.FirstName,' ',m.LastName) AS Mechanic, 
		j.Status,
		j.IssueDate 
FROM Mechanics AS m
JOIN Jobs AS j ON j.MechanicId=m.MechanicId
ORDER BY m.MechanicId ASC,
		j.IssueDate ASC,
		j.JobId ASC

--6
SELECT CONCAT(c.FirstName,' ',c.LastName) AS [Client],
	   DATEDIFF(DAY,j.IssueDate,'2017-04-24') AS [Days going],
	   j.Status
FROM Clients AS c
JOIN Jobs AS j ON j.ClientId=c.ClientId
WHERE J.Status!='Finished'

--7
SELECT CONCAT(M.FirstName,' ', M.LastName), 
	   AVG(DATEDIFF(DAY,J.IssueDate,J.FinishDate)) 
FROM Mechanics AS M
JOIN Jobs AS J ON J.MechanicId=M.MechanicId
GROUP BY M.MechanicId, m.FirstName, m.LastName
ORDER BY M.MechanicId ASC

--8
SELECT CONCAT(M.FirstName,' ',M.LastName) FROM Mechanics AS M
FULL JOIN Jobs AS J ON J.MechanicId=M.MechanicId
WHERE Status='Finished' 
GROUP BY M.MechanicId, M.FirstName,M.LastName
HAVING J.FinishDate IS NOT NULL


SELECT* FROM Mechanics AS M
 JOIN Jobs AS J ON J.MechanicId=M.MechanicId

--9
select J.JobId, SUM(P.Price) AS [Total] from Jobs as j
 JOIN Orders AS o on o.JobId=j.JobId
 join OrderParts as op on op.OrderId=o.OrderId
 join Parts as p on p.PartId=op.PartId
where j.Status='Finished'
GROUP BY J.JobId
ORDER BY J.JobId DESC

select * from Jobs as j
 JOIN Orders AS o on o.JobId=j.JobId
 join OrderParts as op on op.OrderId=o.OrderId
 join Parts as p on p.PartId=op.PartId
where j.Status='Finished'

--10
select p.PartId, p.Description, pn.Quantity as Required, p.StockQty as [In Stock], o.Delivered as [Ordered] from Parts as p
join PartsNeeded as pn on pn.PartId=p.PartId
join Jobs as j on j.JobId=pn.JobId
join Orders as o on o.JobId=o.JobId
join OrderParts as op on op.OrderId=o.OrderId
where j.Status!='Finished' and pn.Quantity>p.StockQty 
group by p.PartId, p.Description,pn.Quantity, p.StockQty, o.Delivered



select * from Orders


--11
go
create proc usp_PlaceOrder(@jobId INT, @serialNum varchar(50),@quantity int)
as
begin
	
end

go

--12 
--Create a user defined function (udf_GetCost) that receives a job’s ID and returns 
--the total cost of all parts that were ordered for it. Return 0 if there are no orders.
--Parameters:
--•	JobId
--Example usage:

go

create function udf_GetCost(@jobId int)
returns decimal
as
begin
 
declare	@sum table=
									(select  p.Price AS [Priee]from Parts as p
									join PartsNeeded as pn on pn.PartId=p.PartId
									join Jobs as j on j.JobId=pn.JobId
									join Orders as o on o.JobId=o.JobId
									join OrderParts as op on op.OrderId=o.OrderId
									where j.JobId=1
									group by j.JobId, p.Price) 
				
 


return @sum;
end

go