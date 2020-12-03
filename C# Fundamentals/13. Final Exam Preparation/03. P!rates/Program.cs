using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._P_rates
{
    public class City
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }

        public City(string name, int population, int gold)
        {
            Name = name;
            Population = population;
            Gold = gold;
        }

        public override string ToString()
        {
            return $"{Name} -> Population: {Population} citizens, Gold: {Gold} kg";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            List<City> cities = new List<City>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Sail")
                {
                    break;
                }

                string[] tokens = input
                    .Split("||", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (cities.Select(x => x.Name).Contains(tokens[0]))
                {
                    City city = cities.Where(x => x.Name == tokens[0]).FirstOrDefault();
                    city.Population += int.Parse(tokens[1]);
                    city.Gold += int.Parse(tokens[2]);
                }
                else
                {
                    City cityToAdd = new City(tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2]));
                    cities.Add(cityToAdd);
                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] commands = line
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string town = string.Empty;
                int gold = 0;

                switch (commands[0])
                {
                    case "Plunder":
                        town = commands[1];
                        int people = int.Parse(commands[2]);
                        gold = int.Parse(commands[3]);

                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                        PlunderCity(town, people, gold, cities);
                        break;
                    case "Prosper":
                        town = commands[1];
                        gold = int.Parse(commands[2]);

                        if (gold < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                            continue;
                        }

                        ProsperCity(town, gold, cities);
                        break;
                }
            }

            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

                foreach (var city in cities.OrderByDescending(x => x.Gold).ThenBy(x => x.Name))
                {
                    Console.WriteLine(city.ToString());
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }

        private static void ProsperCity(string town, int gold, List<City> cities)
        {
            City city = cities.Where(x => x.Name == town).FirstOrDefault();

            city.Gold += gold;

            Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {city.Gold} gold.");
        }

        private static void PlunderCity(string town, int people, int gold, List<City> cities)
        {
            City attackedCity = cities.Where(x => x.Name == town).FirstOrDefault();

            attackedCity.Population -= people;
            attackedCity.Gold -= gold;

            if (attackedCity.Population == 0 || attackedCity.Gold == 0)
            {
                cities.Remove(attackedCity);
                Console.WriteLine($"{town} has been wiped off the map!");
            }
        }
    }
}
