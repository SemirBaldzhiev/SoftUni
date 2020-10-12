using System;

namespace _06._MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            PrintMiddleCharacter(input);
        }

        private static void PrintMiddleCharacter(string input)
        {
            string middleChar = string.Empty;

            if (input.Length % 2 == 0)
            { 

                middleChar += input[(input.Length / 2) - 1];
                middleChar += input[input.Length / 2];
            }
            else
            {
                middleChar += input[input.Length / 2];
            }

            Console.WriteLine(middleChar);
        }
    }
}
