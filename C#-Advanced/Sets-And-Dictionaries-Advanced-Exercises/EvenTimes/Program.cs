using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!dictionary.ContainsKey(num))
                {
                    dictionary.Add(num, 0);
                }

                dictionary[num]++;
            }

            int evenTimesNumber = dictionary.Where(x => x.Value % 2 == 0).Select(x => x.Key).FirstOrDefault();

            Console.WriteLine(evenTimesNumber);
        }
    }
}
