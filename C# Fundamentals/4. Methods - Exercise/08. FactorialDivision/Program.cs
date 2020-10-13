using System;

namespace _08._FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            int factorialFirstNum = Fatctorial(firstNum);
            int factorialSecondNum = Fatctorial(secondNum);

            double division = factorialFirstNum / (double)factorialSecondNum;

            Console.WriteLine($"{division:f2}");

        }

        private static int Fatctorial(int firstNum)
        {
            int fact = 1;

            for (int i = 2; i <= firstNum; i++)
            {
                fact *= i;
            }

            return fact;
        }
    }
}
