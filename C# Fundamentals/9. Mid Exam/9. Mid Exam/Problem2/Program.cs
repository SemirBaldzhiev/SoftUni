using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> friends = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Report")
                {
                    int blacklistedNamesCount = friends.Count(x => x == "Blacklisted");
                    int lostNamesCount = friends.Count(x => x == "Lost");

                    Console.WriteLine($"Blacklisted names: {blacklistedNamesCount}");
                    Console.WriteLine($"Lost names: {lostNamesCount}");
                    Console.WriteLine(string.Join(' ', friends));
                    break;
                }

                string[] commands = input.Split().ToArray();

                string value = commands[1];

                switch (commands[0])
                {
                    case "Blacklist":

                        if (friends.Contains(value))
                        {
                            int indexOfValue = friends.FindIndex(x => x == value);
                            friends[indexOfValue] = "Blacklisted";

                            Console.WriteLine($"{value} was blacklisted.");
                        }
                        else
                        {
                            Console.WriteLine($"{value} was not found.");
                        }
                        break;
                    case "Error":


                        int index = int.Parse(value);
                        
                        if (friends[index] != "Blacklisted" && friends[index] != "Lost")
                        {
                            Console.WriteLine($"{friends[index]} was lost due to an error.");
                            friends[index] = "Lost";
                        }
                        break;
                    case "Change":
                        int newIndex = int.Parse(value);
                        string newName = commands[2];

                        if (newIndex >= 0 && newIndex < friends.Count())
                        {
                            Console.WriteLine($"{friends[newIndex]} changed his username to {newName}.");
                            friends[newIndex] = newName;
                        }

                        break;

                }

            }
        }
    }
}
