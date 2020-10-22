using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());

            string line = Console.ReadLine();

            while (line != "end")
            {

                string[] commands = line.Split().ToArray();

                if (commands.Length == 1)
                {
                    int passengers = int.Parse(commands[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if ((wagons[i] + passengers) <= maxCapacity)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                }
                else
                {
                    int passengers = int.Parse(commands[1]);

                    wagons.Add(passengers);
                }

                line = Console.ReadLine();

            }

            Console.WriteLine(string.Join(' ', wagons));
        }
    }
}
