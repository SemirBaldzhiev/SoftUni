using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> usersInfo = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Statistics")
                {
                    break;
                }

                string[] commands = input
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (commands[0])
                {
                    case "Add":
                        if (!usersInfo.ContainsKey(commands[1]))
                        {
                            usersInfo.Add(commands[1], new List<string>());
                        }
                        else
                        {
                            Console.WriteLine($"{commands[1]} is already registered");
                        }
                        break;
                    case "Send":
                        usersInfo[commands[1]].Add(commands[2]);
                        break;
                    case "Delete":
                        if (usersInfo.ContainsKey(commands[1]))
                        {
                            usersInfo.Remove(commands[1]);
                        }
                        else
                        {
                            Console.WriteLine($"{commands[1]} not found!");
                        }
                        break;
                }
            }

            Console.WriteLine($"Users count: {usersInfo.Count}");

            foreach (var user in usersInfo.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine(user.Key);

                foreach (var email in user.Value)
                {
                    Console.WriteLine($" - {email}");
                }
            }
        }
    }
}
