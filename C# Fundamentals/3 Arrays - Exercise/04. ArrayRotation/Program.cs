using System;
using System.Linq;

namespace _04._ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            int length = numbers.Length;

            for (int i = 0; i < rotations; i++)
            {
                int temp = numbers[0];
                
                for (int j = 0; j < length - 1; j++)
                {
                    numbers[j] = numbers[j + 1];
                }

                numbers[length - 1] = temp;

            }

            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
