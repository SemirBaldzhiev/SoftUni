using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] commands = line.Split().ToArray();
                int index = 0;

                switch (commands[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(commands[1]));
                        break;
                    case "Insert":
                        index = int.Parse(commands[2]);
                        if (index < 0 || index >= numbers.Count)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            numbers.Insert(index, int.Parse(commands[1]));
                        }
                        break;
                    case "Remove":
                        index = int.Parse(commands[1]);
                        if (index < 0 || index >= numbers.Count)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            numbers.RemoveAt(index);
                        }
                        break;
                    case "Shift":
                        if (commands[1] == "left")
                        {
                            ShiftLeft(numbers, int.Parse(commands[2]));
                        }
                        else
                        {
                            ShiftRight(numbers, int.Parse(commands[2]));
                        }
                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }

        private static void ShiftRight(List<int> numbers, int count)
        {
            for (int i = 0; i < count; i++)
            {
                int temp = numbers[numbers.Count - 1];

                for (int j = numbers.Count - 1; j > 0; j--)
                {
                    numbers[j] = numbers[j - 1];
                }

                numbers[0] = temp;
            }
        }

        private static void ShiftLeft(List<int> numbers, int count)
        {
            for (int i = 0; i < count; i++)
            {
                int temp = numbers[0];

                for (int j = 0; j < numbers.Count - 1; j++)
                {
                    numbers[j] = numbers[j + 1];
                }

                numbers[numbers.Count - 1] = temp;
            }
        }
    }
}
