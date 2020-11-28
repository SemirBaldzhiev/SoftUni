using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string namePattern = @"[\W\d]";
            string digitsPattern = @"[\WA-Za-z]";



            List<string> participants = Console.ReadLine().Split(", ").ToList();

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (var name in participants)
            {
                dictionary.Add(name, 0);
            }

            string input = Console.ReadLine();

            

            while (input != "end of race")
            {
                string name = Regex.Replace(input, namePattern, "");
                string digits = Regex.Replace(input, digitsPattern, "");

                int distance = 0;
                foreach (var digit in digits)
                {
                    distance += int.Parse(digit.ToString());
                }

                if (dictionary.ContainsKey(name))
                {
                    dictionary[name] += distance;
                }
                
                input = Console.ReadLine();
            }

            dictionary = dictionary.OrderByDescending(x => x.Value).Take(3).ToDictionary(k => k.Key, v => v.Value);

            string[] result = dictionary.Keys.ToArray();

            Console.WriteLine($"1st place: {result[0]}");
            Console.WriteLine($"2nd place: {result[1]}");
            Console.WriteLine($"3rd place: {result[2]}");


        }
    }
}
