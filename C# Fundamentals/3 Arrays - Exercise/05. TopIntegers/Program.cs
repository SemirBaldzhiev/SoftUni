using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int length = numbers.Length;

            List<int> topIntegers = new List<int>();


            for (int i = 0; i < length; i++)  //14 24 3 19 15 17
            {
                bool isBigger = false;

                for (int j = i + 1; j < length; j++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        isBigger = true;
                    }
                    else
                    {
                        break;
                    }
                }

                if (isBigger)
                {
                    topIntegers.Add(numbers[i]);
                }

            }

            topIntegers.Add(numbers[length - 1]);

            Console.WriteLine(string.Join(" ", topIntegers));
        }
    }
}
