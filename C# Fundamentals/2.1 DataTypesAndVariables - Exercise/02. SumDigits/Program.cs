using System;

namespace _02._SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            int length = number.Length;
            int sumDigits = 0;

            for (int i = 0; i < length; i++)
            {
                sumDigits += int.Parse(number[i].ToString());
            }

            Console.WriteLine(sumDigits);
        }
    }
}
