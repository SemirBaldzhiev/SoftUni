using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();

            List<int> result = new List<int>();

            foreach (var arr in numbers)
            {
                result.AddRange(arr
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList());
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
