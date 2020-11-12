using System;
using System.Collections.Generic;

namespace _01._CountCharsInString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {

                if (input[i] != ' ')
                {
                    if (dictionary.ContainsKey(input[i]))
                    {
                        dictionary[input[i]]++;
                    }
                    else
                    {
                        dictionary.Add(input[i], 1);
                    }
                }
                
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
