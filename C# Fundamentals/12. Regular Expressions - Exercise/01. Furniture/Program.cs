using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<name>[a-zA-z]+)<<(?<price>\d+\.?\d+)!(?<quantity>\d+)";
            Regex regex = new Regex(pattern);
            double totalPrice = 0.0;
            List<string> furnitureNames = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Purchase")
                {
                    break;
                }
                var match = regex.Match(input);

                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    double price = double.Parse(match.Groups[2].Value);
                    int quantity = int.Parse(match.Groups[3].Value);

                    totalPrice += (price * quantity);
                    furnitureNames.Add(name);

                }
            }

            Console.WriteLine("Bought furniture:");
            if (furnitureNames.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, furnitureNames));
            }
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
