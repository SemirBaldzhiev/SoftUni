﻿using System;

namespace _14._ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] arr = input.ToCharArray();

            Array.Reverse(arr);

            Console.WriteLine(new string(arr));

        }
    }
}
