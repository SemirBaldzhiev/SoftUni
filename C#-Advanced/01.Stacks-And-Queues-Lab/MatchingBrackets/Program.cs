using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> bracketIndexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    bracketIndexes.Push(i);
                }

                if (input[i] == ')')
                {
                    int index = bracketIndexes.Pop();
                    string expression = input.Substring(index, i - index + 1);
                    Console.WriteLine(expression);
                }
            }
        }
    }
}
