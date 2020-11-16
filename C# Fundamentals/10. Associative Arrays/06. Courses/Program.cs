using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> coursesInfo = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] commands = input.Split(" : ").ToArray();

                string course = commands[0];
                string student = commands[1];

                if (coursesInfo.ContainsKey(course))
                {
                    coursesInfo[course].Add(student);
                }
                else
                {
                    coursesInfo.Add(course, new List<string>() { student });
                }
            }

            foreach (var course in coursesInfo.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var student in course.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
