using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bombNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int index = numbers.IndexOf(bombNumbers[0]);
            int range = bombNumbers[1];

            while (numbers.Contains(bombNumbers[0]))
            {
                int startIndex = index - range;
                int endIndex = index + range;


                if (startIndex < 0)
                {
                    startIndex = 0;
                }

                if (endIndex > numbers.Count - 1)
                {
                    endIndex = numbers.Count - 1;
                }

                int count = endIndex - startIndex + 1;

                numbers.RemoveRange(startIndex, count);

                index = numbers.IndexOf(bombNumbers[0]);
            }
            int sum = numbers.Sum();

            Console.WriteLine(sum);
        }
    }
}
