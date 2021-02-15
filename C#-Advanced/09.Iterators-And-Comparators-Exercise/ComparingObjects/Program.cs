using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Person> people = new List<Person>();

            while (input != "END")
            {
                string[] personData = input.Split().ToArray();

                Person person = new Person(personData[0], int.Parse(personData[1]), personData[2]);
                people.Add(person);

                input = Console.ReadLine();
            }

            int index = int.Parse(Console.ReadLine());

            var personToCompare = people[index - 1];

            int equalCount = 0;
            int notEqualCount = 0;

            foreach (var person in people)
            {
                if (personToCompare.CompareTo(person) == 0)
                {
                    equalCount++;
                }
                else
                {
                    notEqualCount++;
                }
            }

            if (equalCount > 1)
            {
                Console.WriteLine($"{equalCount} {notEqualCount} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
