using System;

namespace _05._AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int sumNums= Sum(firstNum, secondNum);
            int subtractNums = Subtract(sumNums, thirdNum);

            Console.WriteLine(subtractNums);

        }

        private static int Subtract(int sumNums, int thirdNum)
        {
            return sumNums - thirdNum;
        }

        private static int Sum(int firstNum, int secondNum)
        {
            return firstNum + secondNum;
        }
    }
}
