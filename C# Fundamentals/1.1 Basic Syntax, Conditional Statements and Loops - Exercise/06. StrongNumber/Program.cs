using System;

namespace _06._StrongNumber
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int length = number.Length;
            int sum = 0;

            for (int i = 0; i < length; i++)
            {
                sum += Factorial(int.Parse(number[i].ToString()));
            }

            if (sum == int.Parse(number))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }

        public static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return Factorial(n - 1) * n;
        }

    }
}
