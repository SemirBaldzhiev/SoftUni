using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();

            List<string> filters = new List<string>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Print")
                {
                    break;
                }

                string[] commands = line.Split(";").ToArray();

                if (commands[0] == "Add filter")
                {
                    filters.Add($"{commands[1]} {commands[2]}");
                }
                else if (commands[0] == "Remove filter")
                {
                    filters.Remove($"{commands[1]} {commands[2]}");
                }
            }

            foreach (var filter in filters)
            {
                string[] filterData = filter.Split();

                switch (filterData[0])
                {
                    case "Starts":
                        names = names.Where(x => !x.StartsWith(filterData[2])).ToList();
                        break;
                    case "Ends":
                        names = names.Where(x => !x.EndsWith(filterData[2])).ToList();
                        break;
                    case "Length":
                        names = names.Where(x => x.Length != int.Parse(filterData[1])).ToList();
                        break;
                    case "Contains":
                        names = names.Where(x => !x.Contains(filterData[1])).ToList();
                        break;
                }
            }

            if (names.Count > 0)
            {
                Console.WriteLine(string.Join(" ", names));
            }
        }
    }
}
