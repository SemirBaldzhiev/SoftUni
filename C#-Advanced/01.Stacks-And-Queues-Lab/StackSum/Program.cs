using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> numbers = new Stack<int>(input);

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] commands = line.Split().ToArray();
                string command = commands[0].ToLower();

                if (command == "add")
                {
                    numbers.Push(int.Parse(commands[1]));
                    numbers.Push(int.Parse(commands[2]));
                }
                else if (command == "remove")
                {
                    int count = int.Parse(commands[1]);
                    
                    if (count <= numbers.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }

            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
