using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IBirthable> birthables = new List<IBirthable>();
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] parts = line.Split();

                string type = parts[0];

                if (type == nameof(Citizen))
                {
                    string name = parts[1];
                    int age = int.Parse(parts[2]);
                    string id = parts[3];
                    string birthdate = parts[4];

                    birthables.Add(new Citizen(name, age, id, birthdate));
                }
                else if (type == nameof(Pet))
                {
                    string name = parts[1];
                    string birthdate = parts[2];

                    birthables.Add(new Pet(name, birthdate));
                }
            }

            string filterYear = Console.ReadLine();

            var filtered = birthables.Select(x => x.Birthdate).Where(x => x.EndsWith(filterYear)).ToList();

            foreach (var year in filtered)
            {
                Console.WriteLine(year);
            }

        }
    }
}
