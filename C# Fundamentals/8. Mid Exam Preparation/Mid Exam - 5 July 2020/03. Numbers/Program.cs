using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            double average = numbers.Average();

            numbers = numbers.Where(x => x > average).OrderByDescending(x => x).Take(5).ToList();

            if (numbers.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(string.Join(' ', numbers));
            }

        }
    }
}
