using System;

namespace _08._FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            double factorialFirstNum = Fatctorial(firstNum);
            double factorialSecondNum = Fatctorial(secondNum);

            double division = factorialFirstNum / factorialSecondNum;

            Console.WriteLine($"{division:f2}");

        }

        private static double Fatctorial(int firstNum)
        {
            int fact = 1;

            if (firstNum == 0)
            {
                return fact;
            }

            for (int i = 1; i <= firstNum; i++)
            {
                fact *= i;
            }

            return fact;
        }
    }
}
