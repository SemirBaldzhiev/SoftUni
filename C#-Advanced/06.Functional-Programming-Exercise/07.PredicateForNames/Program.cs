using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            Predicate<string> predicate = x => x.Length <= n;
            List<string> filteredNames = CustomWhere(names, predicate);

            Action<List<string>> printNames = names => Console.WriteLine(string.Join(Environment.NewLine, names));

            printNames(filteredNames);
        }

        private static List<string> CustomWhere(List<string> names, Predicate<string> predicate)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < names.Count; i++)
            {
                if (predicate(names[i]))
                {
                    result.Add(names[i]);
                }
            }

            return result;
        }
    }
}
