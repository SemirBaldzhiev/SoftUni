using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] tokens = line.Split().ToArray();

                Person person = new Person(tokens[0], tokens[1], int.Parse(tokens[2]));

                list.Add(person);
            }

            foreach (var person in list.OrderBy(x => x.Age))
            {
                Console.WriteLine(person.ToString());
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string PersonId { get; set; }
        public int Age { get; set; }

        public Person(string name, string id, int age)
        {
            Name = name;
            PersonId = id;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Name} with ID: {PersonId} is {Age} years old.";
        }
    }
}
