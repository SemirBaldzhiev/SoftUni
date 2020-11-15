using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> products = new Dictionary<string, List<double>>();



            while (true)
            {
                string line = Console.ReadLine();

                if (line == "buy")
                {
                    break;
                }

                string[] productsInfo = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string product = productsInfo[0];
                double price = double.Parse(productsInfo[1]);
                int quantity = int.Parse(productsInfo[2]);

                if (products.ContainsKey(product))
                {

                    products[product][0] += quantity;

                    if (price != products[product][1])
                    {
                        products[product][1] = price;
                    }

                }
                else
                {
                    products.Add(product, new List<double>() { quantity, price });
                }

            }

            
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key} -> {(product.Value[0] * product.Value[1]):f2}");
            }
        }
    }
}
