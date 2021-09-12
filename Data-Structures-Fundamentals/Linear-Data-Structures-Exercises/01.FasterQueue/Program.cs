using Problem01.FasterQueue;
using System;

namespace _01.FasterQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            FastQueue<int> queue = new FastQueue<int>();

            for (int i = 1; i <= 5; i++)
            {
                queue.Enqueue(i);
            }
            queue.Dequeue();

            Console.WriteLine(string.Join(", ", queue));

        }
    }
}
