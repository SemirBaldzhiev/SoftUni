using System;

namespace _10._TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());


            for (int i = 0; i < number; i++)
            {
                if (SumIsDivisibleByEight(i) && HasOneOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool HasOneOddDigit(int number)
        {
            string numStr = number.ToString();

            for (int i = 0; i < numStr.Length; i++)
            {
                if (int.Parse(numStr[i].ToString()) % 2 != 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool SumIsDivisibleByEight(int number)
        {
            string numStr = number.ToString();

            int sumDigits = 0;

            for (int i = 0; i < numStr.Length; i++)
            {
                sumDigits += int.Parse(numStr[i].ToString());
            }

            if (sumDigits % 8 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
