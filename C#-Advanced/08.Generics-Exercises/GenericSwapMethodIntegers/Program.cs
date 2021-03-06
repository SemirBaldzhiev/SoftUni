﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodIntegers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> data = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                data.Add(input);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            Swap(data, firstIndex, secondIndex);
            Print(data);
        }

        private static void Print<T>(List<T> data)
        {
            foreach (var item in data)
            {
                Console.WriteLine($"{item.GetType().FullName}: {item}");
            }
        }

        private static void Swap<T>(List<T> data, int firstIndex, int secondIndex)
        {
            T temp = data[firstIndex];
            data[firstIndex] = data[secondIndex];
            data[secondIndex] = temp;
        }
    }
}
