using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string criteria = Console.ReadLine();

            int start = range[0];
            int end = range[1];



            Func<int, int, List<int>> generateNumbers = (s, e) =>
             {
                 List<int> newList = new List<int>();

                 for (int i = s; i <= e; i++)
                 {
                     newList.Add(i);
                 }

                 return newList;
             };


            List<int> numbers = generateNumbers(start, end);

            Predicate<int> predicate = null;

            if (criteria == "odd")
            {
                predicate = n => n % 2 != 0;
            }
            else if (criteria == "even")
            {
                predicate = n => n % 2 == 0;
            }

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
