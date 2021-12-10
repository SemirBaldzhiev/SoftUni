CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
SELECT FirstName, LastName FROM Employees
WHERE Salary > 35000


EXEC dbo.usp_GetEmployeesSalaryAbove35000

CREATE PROC usp_GetEmployeesSalaryAboveNumber(@number money)
AS 
SELECT FirstName, LastName FROM Employees
WHERE Salary >= @number

EXEC dbo.usp_GetEmployeesSalaryAboveNumber 35000.00

CREATE PROC usp_GetTownsStartingWith (@startString varchar(10))
AS 
SELECT t.[Name]  FROM Towns AS t
WHERE t.[Name] LIKE @startString + '%'

EXEC usp_GetTownsStartingWith 'b'

CREATE PROC usp_GetEmployeesFromTown (@townName varchar(50))
AS
SELECT FirstName, LastName FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
WHERE t.[Name] = @townName


EXEC usp_GetEmployeesFromTown 'Sofia'
