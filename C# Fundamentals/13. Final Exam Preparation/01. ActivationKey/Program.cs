using System;
using System.Linq;

namespace _01._ActivationKey
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            int startIndex = 0;
            int endIndex = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Generate")
                {
                    break;
                }

                string[] commands = input
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (commands[0])
                {
                    case "Contains":
                        string substring = commands[1];
                        if (activationKey.Contains(substring))
                        {
                            Console.WriteLine($"{activationKey} contains {substring}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }

                        break;
                    case "Flip":
                        startIndex = int.Parse(commands[2]);
                        endIndex = int.Parse(commands[3]);

                        string sub = activationKey.Substring(startIndex, endIndex - startIndex);

                        if (commands[1] == "Lower")
                        {
                            activationKey = activationKey.Replace(sub, sub.ToLower());
                        }
                        else
                        {
                            activationKey = activationKey.Replace(sub, sub.ToUpper());
                        }
                        Console.WriteLine(activationKey);
                        break;
                    case "Slice":
                        startIndex = int.Parse(commands[1]);
                        endIndex = int.Parse(commands[2]);

                        activationKey = activationKey.Remove(startIndex, endIndex - startIndex);

                        Console.WriteLine(activationKey);
                        break;
                }

            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
