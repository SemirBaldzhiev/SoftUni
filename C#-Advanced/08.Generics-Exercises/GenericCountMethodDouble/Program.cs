using System;
using System.Collections.Generic;

namespace GenericCountMethodDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<double>> boxes = new List<Box<double>>();

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                Box<double> box = new Box<double>(input);
                boxes.Add(box);
            }

            double criteria = double.Parse(Console.ReadLine());

            Box<double> comparableBox = new Box<double>(criteria);

            int count = GetGreaterThanCount(boxes, comparableBox);

            Console.WriteLine(count);
        }
        private static int GetGreaterThanCount<T>(List<Box<T>> boxes, Box<T> box)
            where T : IComparable
        {
            int count = 0;

            foreach (var item in boxes)
            {
                int compare = item.Value.CompareTo(box.Value);

                if (compare > 0)
                {
                    count++;
                }
            }

            return count;
        }

    }
}
