using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> members = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] personData = Console.ReadLine().Split().ToArray();

                int age = int.Parse(personData[1]);

                Person person = new Person(personData[0], age);

                members.Add(person);
            }

            var membersOverThirty = members.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList();


            foreach (var member in membersOverThirty)
            {
                Console.WriteLine($"{member.Name} - {member.Age}");
            }

        }
    }
}
