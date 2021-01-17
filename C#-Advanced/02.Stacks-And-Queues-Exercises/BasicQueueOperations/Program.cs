using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputData = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = inputData[0];
            int s = inputData[1];
            int x = inputData[2];

            Queue<int> numbers = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                numbers.Enqueue(inputNumbers[i]);
            }

            for (int i = 0; i < s; i++)
            {
                numbers.Dequeue();
            }


            if (numbers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (numbers.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(numbers.Min());
                }
            }

        }
    }
}
