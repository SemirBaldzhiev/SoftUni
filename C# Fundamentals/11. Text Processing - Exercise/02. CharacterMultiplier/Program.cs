using System;
using System.Linq;

namespace _02._CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string firstString = input[0];
            string secondString = input[1];

            int result = CharacterMultiplier(firstString, secondString);


            Console.WriteLine(result);

        }

        private static int CharacterMultiplier(string firstString, string secondString)
        {
            int minLength = Math.Min(firstString.Length, secondString.Length);

            int sum = 0;

            for (int i = 0; i < minLength; i++)
            {
                sum += (firstString[i] * secondString[i]);
            }

            if (firstString.Length > secondString.Length)
            {
                for (int i = minLength; i < firstString.Length; i++)
                {
                    sum += firstString[i];
                }
            }
            else
            {
                for (int i = minLength; i < secondString.Length; i++)
                {
                    sum += secondString[i];
                }
            }

            return sum;
        }
    }
}
