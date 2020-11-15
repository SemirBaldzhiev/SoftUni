using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            Dictionary<string, int> junkItems = new Dictionary<string, int>();

            dictionary.Add("motes", 0);
            dictionary.Add("shards", 0);
            dictionary.Add("fragments", 0);



            bool isObtained = false;
            string legendaryItem = string.Empty;

            while (isObtained == false)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int i = 0; i < input.Length - 1; i+=2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();


                    if (material == "motes")
                    {
                        dictionary[material] += quantity;

                        if (dictionary[material] >= 250)
                        {
                            isObtained = true;
                            legendaryItem = "Dragonwrath";
                        }

                    }
                    else if (material == "fragments")
                    {
                        dictionary[material] += quantity;
                        if (dictionary[material] >= 250)
                        {
                            isObtained = true;
                            legendaryItem = "Valanyr";
                        }

                        
                    }
                    else if (material == "shards")
                    {
                        dictionary[material] +=  quantity;

                        if (dictionary[material] >= 250)
                        {
                            isObtained = true;
                            legendaryItem = "Shadowmourne";
                        }
                        
                    }
                    else
                    {
                        if (junkItems.ContainsKey(material))
                        {
                            junkItems[material] += quantity;
                        }
                        else
                        {
                            junkItems.Add(material, quantity);
                        }
                    }

                    if (isObtained)
                    {
                        dictionary[material] -= 250;
                        break;
                    }

                }
            }

            Console.WriteLine($"{legendaryItem} obtained!");
            
            foreach (var item in dictionary.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in junkItems.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
