SELECT COUNT(*) AS	[Count] FROM WizzardDeposits


SELECT MAX(wd.MagicWandSize) AS LongestMagicWand FROM WizzardDeposits AS wd

SELECT wd.DepositGroup, MAX(wd.MagicWandSize) AS  LongestMagicWand FROM WizzardDeposits AS wd
GROUP BY wd.DepositGroup

SELECT wd.DepositGroup, SUM(wd.DepositAmount) AS  TotalSum FROM WizzardDeposits AS wd
GROUP BY wd.DepositGroup

SELECT wd.DepositGroup, SUM(wd.DepositAmount) AS  TotalSum FROM WizzardDeposits AS wd
WHERE wd.MagicWandCreator = 'Ollivander family'
GROUP BY wd.DepositGroup


SELECT wd.DepositGroup, SUM(wd.DepositAmount) AS TotalSum FROM WizzardDeposits AS wd
WHERE wd.MagicWandCreator = 'Ollivander family'
GROUP BY wd.DepositGroup
HAVING SUM(wd.DepositAmount) < 150000
ORDER BY TotalSum DESC

SELECT wd.DepositGroup, wd.MagicWandCreator, MIN(wd.DepositCharge) AS MinDepositCharge
FROM WizzardDeposits AS wd
GROUP BY wd.DepositGroup, wd.MagicWandCreator
ORDER BY wd.MagicWandCreator, wd.DepositGroup


SELECT 
	CASE
	  WHEN w.Age BETWEEN 0 AND 10 THEN '[0-10]'
	  WHEN w.Age BETWEEN 11 AND 20 THEN '[11-20]'
	  WHEN w.Age BETWEEN 21 AND 30 THEN '[21-30]'
	  WHEN w.Age BETWEEN 31 AND 40 THEN '[31-40]'
	  WHEN w.Age BETWEEN 41 AND 50 THEN '[41-50]'
	  WHEN w.Age BETWEEN 51 AND 60 THEN '[51-60]'
	  WHEN w.Age >= 61 THEN '[61+]'
	END AS [AgeGroup],
COUNT(*) AS [WizardCount]
	FROM WizzardDeposits AS w
GROUP BY CASE
	  WHEN w.Age BETWEEN 0 AND 10 THEN '[0-10]'
	  WHEN w.Age BETWEEN 11 AND 20 THEN '[11-20]'
	  WHEN w.Age BETWEEN 21 AND 30 THEN '[21-30]'
	  WHEN w.Age BETWEEN 31 AND 40 THEN '[31-40]'
	  WHEN w.Age BETWEEN 41 AND 50 THEN '[41-50]'
	  WHEN w.Age BETWEEN 51 AND 60 THEN '[51-60]'
	  WHEN w.Age >= 61 THEN '[61+]'
	END


SELECT DISTINCT LEFT(wd.FirstName, 1) AS FirstLetter FROM WizzardDeposits AS wd
WHERE wd.DepositGroup = 'Troll Chest'
GROUP BY wd.FirstName
ORDER BY FirstLetter


SELECT 
    wd.DepositGroup,
	wd.IsDepositExpired, 
	AVG(wd.DepositInterest) AS AverageInterest
FROM
    WizzardDeposits AS wd
WHERE
    wd.DepositStartDate > '01-01-1985'
GROUP BY wd.DepositGroup, wd.IsDepositExpired
ORDER BY wd.DepositGroup DESC , wd.IsDepositExpired

SELECT e.DepartmentID, SUM(e.Salary) TotalSalary FROM Employees AS e
GROUP BY e.DepartmentID
ORDER BY e.DepartmentID

SELECT e.DepartmentID, MIN(e.Salary) FROM Employees AS e
WHERE e.DepartmentID IN (2, 5, 7) AND e.HireDate > '01-01-2000'
GROUP BY e.DepartmentID

SELECT DepartmentID, MAX(Salary) AS MaxSalary FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000	


SELECT COUNT(*) [Count] FROM Employees AS e
WHERE e.ManagerID IS NULL;



SELECT * INTO AVGSalaries
FROM Employees
WHERE Salary > 30000


DELETE FROM AVGSalaries
WHERE ManagerID = 42;

UPDATE AVGSalaries
	SET Salary = Salary + 5000
	WHERE DepartmentID = 1;
	
SELECT a.DepartmentID, AVG(a.Salary) AS AverageSalary
FROM AVGSalaries AS a
GROUP BY a.DepartmentID