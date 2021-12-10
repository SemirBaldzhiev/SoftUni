CREATE DATABASE WMS

CREATE TABLE Clients
(
	ClientId INT IDENTITY PRIMARY KEY NOT NULL,
	FirstName VARCHAR(50),
	LastName VARCHAR(50),
	Phone CHAR(12)
	CHECK (LEN([Phone]) = 12)
	
)

CREATE TABLE Mechanics
(
	MechanicId INT IDENTITY PRIMARY KEY NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE [Models]
(
	ModelId INT IDENTITY PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Jobs
(
	JobId INT IDENTITY PRIMARY KEY NOT NULL,
	ModelId INT FOREIGN KEY REFERENCES [Models](ModelId) NOT NULL,
	[Status] VARCHAR(11) DEFAULT('Pending') NOT NULL,
	ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE,
	CHECK([Status] IN ('Pending', 'In Progress', 'Finished'))

)

CREATE TABLE Orders
(
	OrderId INT IDENTITY PRIMARY KEY NOT NULL,
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE,
	Delivered BIT DEFAULT(0) NOT NULL,

)

CREATE TABLE Vendors
(
	VendorId INT IDENTITY PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Parts
(
	PartId INT IDENTITY PRIMARY KEY NOT NULL,
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	[Description] VARCHAR(255),
	Price DECIMAL(6, 2) NOT NULL
	CHECK(Price > 0),
	VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId) NOT NULL,
	StockQty INT DEFAULT(0) NOT NULL,
	CHECK(StockQty >= 0)
)

CREATE TABLE PartsNeeded
(
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
	PRIMARY KEY (JobId, PartId),
	Quantity INT DEFAULT(1) NOT NULL,
	CHECK(Quantity > 0)
)

CREATE TABLE OrderParts
(
	OrderId INT FOREIGN KEY REFERENCES Orders(OrderId) NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
	PRIMARY KEY(OrderId, PartId),
	Quantity INT DEFAULT(1) NOT NULL,
	CHECK(Quantity > 0)
)

INSERT INTO Clients (FirstName, LastName, Phone) VALUES
('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie', 'Knipp', '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')


INSERT INTO Parts (SerialNumber, [Description], Price, VendorId) VALUES
('WP8182119', 'Door Boot Seal', 117.86, 2),
('W10780048', 'Suspension Rod', 42.81, 1),
('W10841140', 'Silicone Adhesive', 6.77, 4),
('WPY055980', 'High Temperature Adhesive', 13.94, 3)

UPDATE Jobs
SET MechanicId = 3 
WHERE [Status] = 'Pending'

UPDATE Jobs
SET [Status] = 'In Progress'
WHERE [Status] = 'Pending'

  
DELETE FROM OrderParts
WHERE OrderId = 19

DELETE FROM Orders
WHERE OrderId = 19

SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic, j.[Status], j.IssueDate FROM Mechanics AS m
JOIN Jobs AS j ON m.MechanicId = j.MechanicId
ORDER BY m.MechanicId, j.IssueDate, j.JobId


SELECT CONCAT(c.FirstName, ' ', c.LastName) AS Client, DATEDIFF(day, j.IssueDate, '2017-04-24') AS [Days going], j.[Status] FROM Clients AS c
JOIN Jobs AS j ON c.ClientId = j.ClientId
WHERE j.[Status] != 'Finished'
ORDER BY [Days going] DESC, c.ClientId

SELECT [Mechanic], AVG([Days]) [Average Days]  FROM (
	SELECT  m.MechanicId ,CONCAT(m.FirstName, ' ', m.LastName) AS [Mechanic], DATEDIFF(day, j.IssueDate, j.FinishDate) AS [Days] FROM Mechanics AS m
	JOIN Jobs AS j ON m.MechanicId = j.MechanicId
	WHERE j.[Status] = 'Finished'
) AS [DaysWorkSubQuery]
GROUP BY MechanicId, [Mechanic]
ORDER BY MechanicId

--CONCAT(m.FirstName, ' ', m.LastName) AS Available 


SELECT m.MechanicId ,CONCAT(m.FirstName, ' ', m.LastName) AS [Available] FROM Mechanics AS m
JOIN Jobs AS j ON m.MechanicId = j.MechanicId
WHERE j.[Status] = 'Finished'
ORDER BY M.MechanicId

SELECT CONCAT(mh.FirstName, ' ', mh.LastName) AS [Available] FROM Mechanics AS mh
WHERE mh.MechanicId NOT IN (
	SELECT DISTINCT m.MechanicId FROM  Mechanics AS m
	JOIN Jobs AS j ON m.MechanicId = j.MechanicId
	WHERE j.[Status] != 'Finished')
ORDER BY mh.MechanicId

SELECT j.JobId, 
ISNULL(SUM(p.Price * op.Quantity), 0) AS Total 
FROM Jobs AS j
LEFT JOIN Orders AS o ON j.JobId = o.JobId
LEFT JOIN OrderParts AS op ON o.OrderId = op.OrderId
LEFT JOIN Parts AS p ON op.PartId = p.PartId
WHERE j.[Status] = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId 