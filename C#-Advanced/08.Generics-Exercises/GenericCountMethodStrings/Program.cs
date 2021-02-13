using System;
using System.Collections.Generic;

namespace GenericCountMethodStrings
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Box<string>> boxes = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Box<string> box = new Box<string>(input);
                boxes.Add(box);
            }

            string criteria = Console.ReadLine();

            Box<string> comparableBox = new Box<string>(criteria);

            int count = GetGreaterThanCount(boxes, comparableBox);

            Console.WriteLine(count);
        }

        private static int GetGreaterThanCount<T>(List<Box<T>> boxes, Box<T> box) 
            where T: IComparable
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
