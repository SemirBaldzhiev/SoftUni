using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {

        static void Main(string[] args)
        {
            var dbContext = new SoftUniContext();
            string result;
            //result = GetEmployeesFullInformation(dbContext);
            //result = GetEmployeesWithSalaryOver50000(dbContext);
            //result = GetEmployeesFromResearchAndDevelopment(dbContext);
            //result = AddNewAddressToEmployee(dbContext);
            //result = GetEmployeesInPeriod(dbContext);
            //result = GetAddressesByTown(dbContext);
                
            //result = GetEmployee147(dbContext); ????
            //result = GetDepartmentsWithMoreThan5Employees(dbContext);

            //result = GetLatestProjects(dbContext);

            result = GetEmployeesByFirstNameStartingWithSa(dbContext);

            Console.WriteLine(result);

        }

        // Problem 3
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var allEmplayees = context.Employees
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    MiddleName = e.MiddleName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary
                }
                )
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in allEmplayees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString();

        }

        // Problem 4
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString();
        }

        // Problem 5
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");
            }

            return sb.ToString();
        }

        // Problem 6
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var nakovEmployee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            nakovEmployee.Address = newAddress;
            context.SaveChanges();

            var addresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToList();

            foreach (var address in addresses)
            {
                sb.AppendLine(address);
            }

            return sb.ToString(); ;
        }

        // Problem 7
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                 .Include(x => x.Manager)
                 .Include(x => x.EmployeesProjects)
                 .ThenInclude(x => x.Project)
                 .Where(e => e.EmployeesProjects
                     .Any(p => p.Project.StartDate.Year >= 2001
                                     && p.Project.StartDate.Year <= 2003))
                 .Take(10)
                 .ToList();

            foreach (var employee in employees)
            {
                    
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.Manager.FirstName} {employee.Manager.LastName}");

                foreach (var project in employee.EmployeesProjects)
                {
                    if (project.Project.EndDate != null)
                    {
                       sb.AppendLine($"--{project.Project.Name} - {project.Project.StartDate} - {project.Project.EndDate}");
                    }
                    else
                    {
                        sb.AppendLine($"--{project.Project.Name} - {project.Project.StartDate} - not finished");
                    }
                   
                }
            }

            return sb.ToString();
        }

        // Problem 8
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context.Addresses
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    Count = a.Employees.Count()
                })
                .OrderByDescending(a => a.Count)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.Count} employees");
            }

            return sb.ToString();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee = context.Employees.Find(147);

            var projects = employee.EmployeesProjects.OrderBy(project => project.Project.Name);

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var project in projects)
            {
                sb.AppendLine(project.Project.Name);
            }


            return sb.ToString();
        }

        // Problem 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {

            StringBuilder sb = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count() > 5)
                .OrderBy(d => d.Employees.Count())
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees
                        .Select(e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.JobTitle
                        })
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                        .ToList()
                })
                .ToList();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} – {department.ManagerFirstName} {department.ManagerLastName}");

                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString();
        }

        // Problem 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var lastProjects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderBy(p => p.Name)
                .ToList();

            foreach (var project in lastProjects)
            {
                sb.AppendLine($"{project.Name}\n{project.Description}\n{project.StartDate}");
            }

            return sb.ToString();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                    || e.Department.Name == "Tool Design"
                    || e.Department.Name == "Marketing"
                    || e.Department.Name == "Information Services")
                .ToList();

            foreach (var emp in employees)
            {
                emp.Salary += emp.Salary * 0.12M;
            }

            context.SaveChanges();

            var updatedEmployees = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                    || e.Department.Name == "Tool Design"
                    || e.Department.Name == "Marketing"
                    || e.Department.Name == "Information Services")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            var result = new StringBuilder();

            foreach (var emp in updatedEmployees)
            {
                result.AppendLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:F2})");
            }

            return result.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => EF.Functions.Like(e.FirstName, "sa%"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return sb.ToString();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectToRemove = context.Projects
                .FirstOrDefault(p => p.ProjectId == 2);

            var employeesProjects = context.EmployeesProjects
                .Where(p => p.ProjectId == 2)
                .ToList();

            foreach (var employeeProject in employeesProjects)
            {
                context.EmployeesProjects.Remove(employeeProject);
            }

            context.Projects.Remove(projectToRemove);

            context.SaveChanges();

            var projects = context.Projects
                .Select(p => p.Name)
                .Take(10)
                .ToList();

            var result = new StringBuilder();

            foreach (var name in projects)
            {
                result.AppendLine(name);
            }

            return result.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var addressIdsToRemove = context.Addresses
                .Where(a => a.Town.Name == "Seattle")
                .Select(a => a.AddressId)
                .ToList();

            var employees = context.Employees
                .ToList();

            foreach (var id in addressIdsToRemove)
            {
                foreach (var emp in employees)
                {
                    emp.AddressId = null;
                }
            }

            var addressesToRemove = context.Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToList();

            foreach (var address in addressesToRemove)
            {
                context.Addresses.Remove(address);
            }

            var townToRemove = context.Towns
                .FirstOrDefault(t => t.Name == "Seattle");

            context.Towns.Remove(townToRemove);

            context.SaveChanges();

            return $"{addressesToRemove.Count} addresses in Seattle were deleted";
        }
    }
}
