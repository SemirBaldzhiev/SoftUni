using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());

            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            for (int i = 0; i < commandsCount; i++)
            {
                string[] commands = Console.ReadLine()
                    .Split()
                    .ToArray();

                string username = commands[1];

                switch (commands[0])
                {
                    case "register":
                        
                        string licenseNumber = commands[2];

                        if (dictionary.ContainsKey(username))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {licenseNumber}");
                        }
                        else
                        {
                            dictionary.Add(username, licenseNumber);
                            Console.WriteLine($"{username} registered {licenseNumber} successfully");
                        }

                        break;
                    case "unregister":
                        if (dictionary.ContainsKey(username))
                        {
                            dictionary.Remove(username);
                            Console.WriteLine($"{username} unregistered successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: user {username} not found");
                        }
                        break;
                }
            }

            foreach (var user in dictionary)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
