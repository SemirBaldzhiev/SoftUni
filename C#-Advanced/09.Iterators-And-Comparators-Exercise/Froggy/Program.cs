using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToList();

            Lake lake = new Lake(numbers);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
