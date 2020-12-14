using System;
using System.Text.RegularExpressions;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<!.)(\$|%)([A-Z][a-z]{2,})\1:\s(?:\[([0-9]+)\]\|)(?:\[([0-9]+)\]\|)(?:\[([0-9]+)\]\|)(?!.)";

            int n = int.Parse(Console.ReadLine());

            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                var match = regex.Match(line);

                if (match.Success)
                {
                    string name = match.Groups[2].Value;

                    string decrypted = string.Empty;

                    decrypted += (char)(int.Parse(match.Groups[3].Value));
                    decrypted += (char)(int.Parse(match.Groups[4].Value));
                    decrypted += (char)(int.Parse(match.Groups[5].Value));

                    Console.WriteLine($"{name}: {decrypted}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
