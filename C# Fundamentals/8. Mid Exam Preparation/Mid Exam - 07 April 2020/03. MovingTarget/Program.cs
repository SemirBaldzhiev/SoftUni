using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    Console.WriteLine(string.Join('|', targets));
                    break;
                }

                string[] commands = input.Split().ToArray();
                int index = int.Parse(commands[1]);
                int value = int.Parse(commands[2]);

                switch (commands[0])
                {
                    case "Shoot":
                        if (IsValidIndex(index, targets))
                        {
                            targets[index] -= value;

                            if (targets[index] <= 0)
                            {
                                targets.RemoveAt(index);
                            }
                        }
                        
                        break;
                    case "Add":
                        if (IsValidIndex(index, targets))
                        {
                            targets.Insert(index, value);
                        }
                        else
                        {
                            Console.WriteLine("Invalid placement!");
                        }
                        break;
                    case "Strike":
                        if (IsValidIndex(index, targets) && IsValidIndex(index + value, targets) && IsValidIndex(index - value, targets))
                        {
                            targets.RemoveRange(index - value, (2 * value) + 1);
                        }
                        else
                        {
                            Console.WriteLine("Strike missed!");
                        }
                        break;
                }
            }
        }

        static bool IsValidIndex(int index, List<int> list)
        {
            if (index < 0 || index >= list.Count())
            {
                return false;
            }

            return true;
        }
    }
}
