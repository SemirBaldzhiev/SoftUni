using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        { 
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] ordersData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> orders = new Queue<int>(ordersData);
            bool isCompleted = true;
            int count = orders.Count();

            int maxOrder = orders.Max();

            for (int i = 0; i < count; i++)
            {
                if (foodQuantity - orders.Peek() >= 0)
                {
                    foodQuantity -= orders.Dequeue();
                }
                else
                {
                    isCompleted = false;
                    break;
                }
            }

            Console.WriteLine(maxOrder);

            if (isCompleted)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
        }
    }
}
