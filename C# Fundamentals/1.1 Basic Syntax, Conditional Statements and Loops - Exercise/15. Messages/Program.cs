using System;
using System.Collections.Generic;

namespace _15._Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, char[]> dict = new Dictionary<int, char[]>();

            dict.Add(0, new char[] { ' ' });
            dict.Add(2, new char[] { 'a', 'b', 'c' });
            dict.Add(3, new char[] { 'd', 'e', 'f' });
            dict.Add(4, new char[] { 'g', 'h', 'i' });
            dict.Add(5, new char[] { 'j', 'k', 'l' });
            dict.Add(6, new char[] { 'm', 'n', 'o' });
            dict.Add(7, new char[] { 'p', 'q', 'r', 's' });
            dict.Add(8, new char[] { 't', 'u', 'v' });
            dict.Add(9, new char[] { 'w', 'x', 'y', 'z'});


            string result = "";


            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                
                int index = input.Length - 1;
                int key = int.Parse(input[0].ToString());
                result += dict[key][index].ToString();
             
            }

            Console.WriteLine(result);
        }
    }
}
