using System;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] train = new int[n];
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int wagon = int.Parse(Console.ReadLine());
                train[i] = wagon;
                sum += wagon;
            }

            Console.WriteLine(string.Join(" ", train));
            Console.WriteLine(sum);
        }
    }
}
