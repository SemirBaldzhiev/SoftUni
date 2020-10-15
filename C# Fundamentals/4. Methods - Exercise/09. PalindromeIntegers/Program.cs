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
            
            if (number.ToString() == number.ToString().Reverse().ToString())
            {
                return true;
            }

            return false;
        }
    }
}
