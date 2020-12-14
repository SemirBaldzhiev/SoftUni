using System;
using System.Linq;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (commands[0])
                {
                    case "Translate":
                        text = text.Replace(commands[1], commands[2]);
                        Console.WriteLine(text);
                        break;
                    case "Includes":
                        if (text.Contains(commands[1]))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                        break;
                    case "Start":
                        if (text.StartsWith(commands[1]))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                        break;
                    case "Lowercase":
                        text = text.ToLower();
                        Console.WriteLine(text);
                        break;
                    case "FindIndex":
                        int index = text.LastIndexOf(commands[1]);
                        Console.WriteLine(index);
                        break;
                    case "Remove":
                        text = text.Remove(int.Parse(commands[1]), int.Parse(commands[2]));
                        Console.WriteLine(text);
                        break;
                }
            }
        }
    }
}
