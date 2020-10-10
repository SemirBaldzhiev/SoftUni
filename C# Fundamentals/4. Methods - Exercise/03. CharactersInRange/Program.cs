using System;

namespace _03._CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            BetweenCharInAscii(firstChar, secondChar);
        }

        private static void BetweenCharInAscii(char firstChar, char secondChar)
        {
            int firstCharAscii = (int)firstChar;
            int secondCharAscii = (int)secondChar;

            for (int i = firstCharAscii + 1; i < secondCharAscii; i++)
            {
                Console.WriteLine($"{(char)i} ");
            }
        }
    }
}
