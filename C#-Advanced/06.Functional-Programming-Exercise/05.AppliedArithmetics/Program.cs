using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            Func<List<int>, List<int>> add = nums => nums.Select(x => x + 1).ToList();
            Func<List<int>, List<int>> multiply = nums => nums.Select(x => x * 2).ToList();
            Func<List<int>, List<int>> subtract = nums => nums.Select(x => x - 1).ToList();
            Action<List<int>> print = nums => Console.WriteLine(string.Join(" ", nums));

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                switch (command)
                {
                    case "add":
                        numbers = add(numbers);
                        break;
                    case "multiply":
                        numbers = multiply(numbers);
                        break;
                    case "subtract":
                        numbers = subtract(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                }

            }
        }
    }
}
