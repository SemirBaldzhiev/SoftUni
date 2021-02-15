using System;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] commands = input.Split(new string[] { " ", ", "}, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = commands[0];

                if (command == "Push")
                {
                    for (int i = 1; i < commands.Length; i++)
                    {
                        stack.Push(int.Parse(commands[i]));
                    }
                }
                else if (command == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                }

                input = Console.ReadLine();
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(string.Join(Environment.NewLine, stack));
        }
    }
}
