using System;
using System.Text.RegularExpressions;

namespace _03._SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%([A-Z][a-z]+)%[^|$%.]*<(\w+)>[^|$%.]*\|(\d+)\|[^|$%.]*?(\d+\.?\d+)\$";
            
            string input = Console.ReadLine();
            Regex regex = new Regex(pattern);
            double totalIncome = 0.0;

            while (input != "end of shift")
            {
                var match = regex.Match(input);

                if (match.Success)
                {
                    string customer = match.Groups[1].Value;
                    string product = match.Groups[2].Value;
                    int count = int.Parse(match.Groups[3].Value);
                    double price = double.Parse(match.Groups[4].Value);

                    double totalPrice = count * price;

                    Console.WriteLine($"{customer}: {product} - {totalPrice:f2}");

                    totalIncome += totalPrice;
                }


                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
