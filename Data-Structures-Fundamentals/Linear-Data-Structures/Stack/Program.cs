using System;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);

            }

            Console.WriteLine(stack.Count);

            Console.WriteLine(stack.Peek());

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }

        }
    }
}
