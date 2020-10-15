using System;
using System.Linq;

namespace _09._PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                int number = int.Parse(input);

                bool result = IsPalindrome(number);

                Console.WriteLine(result.ToString().ToLower());
            }
        }

        private static bool IsPalindrome(int number)
        {

            string numStr = number.ToString();
            char[] array = numStr.ToCharArray();
            Array.Reverse(array);
            string numStrReverse = new string(array);
                
            if (numStr == numStrReverse)
            {
                return true;
            }

            return false;
        }
    }
}
