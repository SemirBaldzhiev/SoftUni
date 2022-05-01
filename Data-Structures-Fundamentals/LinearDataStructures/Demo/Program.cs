using Problem03.Queue;
using System;

namespace Demo // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IAbstractQueue<int> q = new Problem03.Queue.Queue<int>();

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);   
            q.Enqueue(4);
            q.Enqueue(5);
            q.Enqueue(6);
            q.Enqueue(7);
            q.Enqueue(8);


            Console.WriteLine(q.Count);
        }
    }
}