using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> chemicalElements = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split().ToArray();

                for (int j = 0; j < elements.Length; j++)
                {
                    chemicalElements.Add(elements[j]);
                }
            }

            Console.WriteLine(string.Join(" ", chemicalElements.OrderBy(x => x)));
        }
    }
}
