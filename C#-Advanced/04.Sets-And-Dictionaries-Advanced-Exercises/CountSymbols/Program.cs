using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> symbolsCount = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!symbolsCount.ContainsKey(text[i]))
                {
                    symbolsCount.Add(text[i], 0);
                }

                symbolsCount[text[i]]++;
            }

            foreach (var symbol in symbolsCount.OrderBy(s => s.Key))
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }

        }
    }
}
