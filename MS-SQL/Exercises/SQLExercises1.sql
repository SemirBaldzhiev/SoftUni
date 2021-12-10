SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name] FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.DepartmentID = 3
ORDER BY e.EmployeeID

SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.[Name]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE E.Salary > 15000
ORDER BY e.DepartmentID

SELECT TOP(3) e.EmployeeID, e.FirstName 
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
WHERE ep.EmployeeID IS NULL
ORDER BY e.EmployeeID

SELECT e.FirstName, e.LastName, e.HireDate, d.[Name] FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '01.01.1999' AND (e.DepartmentID = 3 OR e.DepartmentID = 10)
ORDER BY HireDate

SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name] AS ProjectName FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND (p.EndDate IS NULL)
ORDER BY e.EmployeeID

SELECT e.EmployeeID, e.FirstName, p.[Name] AS ProjectName 
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects AS p ON ep.ProjectID = p.ProjectID AND p.StartDate < '2005-01-01'
WHERE e.EmployeeID = 24

SELECT TOP(50) e.EmployeeID, CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName, CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName, d.[Name] AS DepartmentNane
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY E.EmployeeID


SELECT MIN(avg) AS [MinAverageSalary]
FROM (
       SELECT AVG(Salary) AS [avg]
       FROM Employees
       GROUP BY DepartmentID
     ) AS AverageSalary

SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation FROM Mountains AS m
JOIN Peaks AS p ON m.Id = p.MountainId
JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
WHERE mc.CountryCode = 'BG' AND P.Elevation > 2835
ORDER BY p.Elevation DESC




SELECT mc.CountryCode, COUNT(m.MountainRange) FROM Mountains AS m
JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
WHERE mc.CountryCode IN ('BG', 'RU', 'US')
GROUP BY mc.CountryCode


SELECT TOP(5) c.CountryName, r.RiverName FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON CR.RiverId = r.Id
WHERE c.ContinentCode  = 'AF'
ORDER BY C.CountryName

SELECT COUNT(*) AS [Count] FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
WHERE MC.MountainId IS NULL


SELECT TOP(5) c.CountryName, MAX(p.Elevation) AS [HighestPeakElevation], MAX(r.[Length]) AS [LongestRiverLength]
FROM Countries AS c
LEFT OUTER JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT OUTER JOIN Peaks AS p ON p.MountainId = mc.MountainId
LEFT OUTER JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT OUTER JOIN Rivers AS r ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, c.CountryName