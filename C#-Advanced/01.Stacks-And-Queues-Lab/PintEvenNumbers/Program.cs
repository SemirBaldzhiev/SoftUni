using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> numbers = new Queue<int>();

            for (int i = 0; i < inputData.Length; i++)
            {
                if (inputData[i] % 2 == 0)
                {
                    numbers.Enqueue(inputData[i]);
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
