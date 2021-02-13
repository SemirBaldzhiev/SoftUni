using System;
using System.Collections.Generic;

namespace GenericBoxOfIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<int>> boxes = new List<Box<int>>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(input);
                boxes.Add(box);
            }

            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }
    }
}
