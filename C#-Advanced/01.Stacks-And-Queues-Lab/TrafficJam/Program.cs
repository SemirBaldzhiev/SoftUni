﻿using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
       ConsoleApp1 static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int count = 0;

            string input = Console.ReadLine();

            while (input != "end")
            {
                if (input == "green")
                {
                    if (n > cars.Count)
                    {
                        n = cars.Count;
                    }

                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        count++;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
