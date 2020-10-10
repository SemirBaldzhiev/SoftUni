using System;

namespace _02._VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            input = input.ToLower();
            int countVowels = VowelsCount(input);

            Console.WriteLine(countVowels);
        }

        private static int VowelsCount(string input)
        {
            int length = input.Length;
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                if (input[i] == 'a' || input[i] == 'u' || input[i] == 'i' || input[i] == 'e' || input[i] == 'o')
                {
                    count++;
                }
            }

            return count;
        }
    }
}
