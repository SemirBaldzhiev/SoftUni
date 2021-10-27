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
            result = GetEmployeesInPeriod(dbContext);
            Console.WriteLine(result);

        }

        //Problem 3
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

        //Problem 4
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

        //Problem 5
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

        //Problem 6
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

        //Problem 7
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

        public static string GetAddressesByTown(SoftUniContext context)
        {



            return "";
        }

    }
}
