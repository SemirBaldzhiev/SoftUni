using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Stack<string> expression = new Stack<string>();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                expression.Push(input[i]);
            }

            while (expression.Count > 1)
            {
                int firstNumber = int.Parse(expression.Pop());
                string sign = expression.Pop();
                int secondNumber = int.Parse(expression.Pop());

                if (sign == "+")
                {
                    expression.Push((firstNumber + secondNumber).ToString());
                }
                if (sign == "-")
                {
                    expression.Push((firstNumber - secondNumber).ToString());
                }

            }

            Console.WriteLine(expression.Pop());
        }
    }
}
