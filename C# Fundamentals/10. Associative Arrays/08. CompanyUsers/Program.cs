using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] commands = input
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string company = commands[0];
                string employeeId = commands[1];

                if (companies.ContainsKey(company))
                {
                    if (!companies[company].Contains(employeeId))
                    {
                        companies[company].Add(employeeId);
                    }
                    
                }
                else
                {
                    companies.Add(company, new List<string> { employeeId });
                }

            }

            foreach (var company in companies.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{company.Key}");
                        
                foreach (var employeeId in company.Value)
                {
                    Console.WriteLine($"-- {employeeId}");
                }
            }
        }
    }
}
