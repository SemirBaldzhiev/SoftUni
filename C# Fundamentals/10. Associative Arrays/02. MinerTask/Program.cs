using System;
using System.Collections.Generic;

namespace _02._MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> dictionary = new Dictionary<string, int>(); 

            while (true)
            {
                string resource = Console.ReadLine();

                if (resource == "stop")
                {
                    break;
                }

                int quantity = int.Parse(Console.ReadLine());

                if (dictionary.ContainsKey(resource))
                {
                    dictionary[resource] += quantity;
                }
                else
                {
                    dictionary.Add(resource, quantity);
                }

            }


            foreach (var resource in dictionary)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }

        }
    }
}
