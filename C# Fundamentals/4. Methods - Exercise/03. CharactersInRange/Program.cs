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
            int start = 0;
            int end = 0;

            if (firstCharAscii > secondChar)
            {
                end = firstCharAscii;
                start = secondCharAscii;
            }
            else
            {
                start = firstCharAscii;
                end = secondCharAscii;
            }

            

            for (int i = start + 1; i < end; i++)
            {
                Console.WriteLine($"{(char)i} ");
            }
        }
    }
}
