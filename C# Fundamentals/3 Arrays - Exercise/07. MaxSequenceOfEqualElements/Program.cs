using System;
using System.Linq;

namespace _07._MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int length = numbers.Length;
            int element = numbers[0];
            int count = 1;

            int maxCount = 0;
            int bestElement = 0;

            for (int i = 0; i < length - 1; i++) //2 1 1 2 3 3 2 2 2 1
            {

                if (numbers[i] == numbers[i + 1])
                {
                    element = numbers[i];
                    count++;
                }
                else
                {
                    count = 1;
                }


                if (count > maxCount)
                {
                    maxCount = count;
                    bestElement = element;
                }

            }

            for (int i = 0; i < maxCount; i++)
            {
                Console.Write(bestElement + " ");
            }
        }
    }
}
