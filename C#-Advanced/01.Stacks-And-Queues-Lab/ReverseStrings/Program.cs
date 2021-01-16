using System;
using System.Collections.Generic;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> reverseInput = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                reverseInput.Push(input[i]);
            }

            foreach (var ch in reverseInput)
            {
                Console.Write(ch);
            }
            Console.WriteLine();
        }
    }
}
