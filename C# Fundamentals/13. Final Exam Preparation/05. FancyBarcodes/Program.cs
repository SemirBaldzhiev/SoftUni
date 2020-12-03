using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05._FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@#+([A-Z][A-Za-z0-9]{4,}[A-Z])@#+";
            int n = int.Parse(Console.ReadLine());

            Regex regex = new Regex(pattern); 

            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();
                string productGroup = string.Empty;

                var match = regex.Match(barcode);

                if (match.Success)
                {
                    string filter = "0123456789";

                    productGroup = new string(match.Groups[1].Value.Where(x => filter.Contains(x)).ToArray());

                    if (productGroup == string.Empty)
                    {
                        productGroup = "00";
                    }

                    Console.WriteLine($"Product group: {productGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }

            }
        }
    }
}
