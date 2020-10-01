using System;
using System.Linq;

namespace _08._MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int num = int.Parse(Console.ReadLine());

            int length = numbers.Length;

            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (numbers[i] + numbers[j] == num)
                    {
                        Console.WriteLine($"{numbers[i]} {numbers[j]}");
                    }
                }

                
            }

        }
    }
}
