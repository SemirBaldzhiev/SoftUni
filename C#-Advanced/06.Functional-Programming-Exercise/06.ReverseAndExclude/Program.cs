using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());

            numbers.Reverse();

            Predicate<int> predicate = x => x % n != 0;

            List<int> filteredNumbers = CustomWhere(numbers, predicate);

            Console.WriteLine(string.Join(" ", filteredNumbers));
        }

        private static List<int> CustomWhere(List<int> numbers, Predicate<int> predicate)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (predicate(numbers[i]))
                {
                    result.Add(numbers[i]);
                }
            }

            return result;
        }
    }
}
