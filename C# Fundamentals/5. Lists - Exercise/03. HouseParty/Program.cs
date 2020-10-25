using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> members = new List<string>();

            for (int i = 1; i <= numberOfCommands; i++)
            {
                string command = Console.ReadLine();

                string[] tokens = command.Split().ToArray();

                string name = tokens[0];

                if (tokens.Length == 3)
                {
                    if (!members.Contains(name))
                    {
                        members.Add(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                }
                else
                {
                    if (members.Contains(name))
                    {
                        members.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, members));
                    
        }
    }
}
