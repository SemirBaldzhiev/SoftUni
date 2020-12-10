using System;
using System.Linq;

namespace _10._WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Travel")
                {
                    break;
                }

                string[] commands = input
                    .Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (commands[0])
                {
                    case "Add Stop":
                        int index = int.Parse(commands[1]);
                        if (index >= 0 && index < stops.Length)
                        {
                            stops = stops.Insert(index, commands[2]);
                            
                        }
                        break;
                    case "Remove Stop":
                        int startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);

                        if (startIndex >=0 && endIndex < stops.Length)
                        {
                            stops = stops.Remove(startIndex, endIndex - startIndex + 1);
                        }
                        break;
                    case "Switch":
                        if (stops.Contains(commands[1]))
                        {
                            stops = stops.Replace(commands[1], commands[2]);
                        }
                        break;
                }

                Console.WriteLine(stops);
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
