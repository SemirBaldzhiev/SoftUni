using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split().ToArray();

                switch (commands[0])
                {
                    case "1":
                        numbers.Push(int.Parse(commands[1]));
                        break;
                    case "2":
                        if (numbers.Count > 0)
                        {
                            numbers.Pop();
                        }
                        break;
                    case "3":
                        if (numbers.Count > 0)
                        {
                            Console.WriteLine(numbers.Max());
                        }
                        break;
                    case "4":
                        if (numbers.Count > 0)
                        {
                            Console.WriteLine(numbers.Min());
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
