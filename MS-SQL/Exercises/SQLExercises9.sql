SELECT FirstName, LastName FROM Employees
WHERE FirstName LIKE 'Sa%'


SELECT FirstName, LastName FROM Employees
WHERE LastName LIKE '%ei%'

SELECT FirstName FROM Employees
WHERE (DepartmentID = 3 OR DepartmentID = 10) AND (HireDate BETWEEN '1995-12-31' AND '2005-12-31')

SELECT FirstName, LastName FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

SELECT [Name] FROM Towns
WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
ORDER BY [Name]


SELECT TownID, [Name] FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

SELECT TownID, [Name] FROM Towns
WHERE [Name] LIKE '[^RBD]%'
ORDER BY [Name]

SELECT FirstName, LastName FROM Employees
WHERE LEN(LastName) = 5






