using System;
using System.Collections.Generic;

namespace BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            //{[(}]}
            string input = Console.ReadLine();

            Stack<char> brackets = new Stack<char>();
            bool isBalanced = true;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '[' || input[i] == '{'  || input[i] == '(')
                {
                    brackets.Push(input[i]);
                }
                else
                {
                    if (brackets.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }

                    bool isfirstBracketValid = input[i] == ')' && brackets.Pop() == '(';//false
                    bool isSecondBracketValid = input[i] == '}' && brackets.Pop() == '{'; //false
                    bool isThirdBracketValid = input[i] == ']' && brackets.Pop() == '[';//false

                    if (!isfirstBracketValid && !isSecondBracketValid && !isThirdBracketValid)
                    {
                        isBalanced = false;
                        break;
                    }
                }
                
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
