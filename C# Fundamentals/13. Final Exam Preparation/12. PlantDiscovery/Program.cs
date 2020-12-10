using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._PlantDiscovery
{
    public class Plant
    {
        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<int> Rating { get; set; }

        public Plant(string name, int rarity)
        {
            this.Name = name;
            this.Rarity = rarity;
            this.Rating = new List<int>();
        }

        
        public override string ToString()
        {
            return String.Format("- {0}; Rarity: {1}; Rating: {2:f2}", Name, Rarity, Rating.Count > 0 ? Rating.Average() : 0); 
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Plant> plants = new List<Plant>();

            for (int i = 0; i < n; i++)
            {
                string[] plantsInfo = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Plant plant = null;
                if (plants.Select(x => x.Name).Contains(plantsInfo[0]))
                {
                    plant = plants.Where(x => x.Name == plantsInfo[0]).FirstOrDefault();
                    plant.Rarity = int.Parse(plantsInfo[1]);
                }
                else
                {
                    plant = new Plant(plantsInfo[0], int.Parse(plantsInfo[1]));
                    plants.Add(plant);
                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Exhibition")
                {
                    break;
                }

                string[] commands = line
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string[] data = commands[1]
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Plant plant = null;

                if (plants.Select(x => x.Name).Contains(data[0]))
                {
                    plant = plants.Where(x => x.Name == data[0]).FirstOrDefault();
                }
                else
                {
                    Console.WriteLine("error");
                    continue;
                }

                switch (commands[0])
                {
                    case "Rate":
                        plant.Rating.Add(int.Parse(data[1]));
                        break;
                    case "Update":
                        plant.Rarity = int.Parse(data[1]);
                        break;
                    case "Reset":
                        plant.Rating = new List<int>();
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                   
                }
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (var plant in plants.OrderByDescending(x =>x.Rarity).ThenByDescending(x => x.Rating.Count > 0 ? x.Rating.Average() : 0))
            {
                Console.WriteLine(plant.ToString());
            }
        }
    }
}
