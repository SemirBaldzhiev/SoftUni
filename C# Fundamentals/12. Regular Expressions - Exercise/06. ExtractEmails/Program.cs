using System;
using System.Text.RegularExpressions;

namespace _06._ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"(?<=\s)([A-Za-z0-9]+[\.\-_]?[A-Za-z0-9]+)@([A-Za-z]+[\-]?[A-Za-z]+)(\.([A-Za-z]+)){1,}";

            Regex regex = new Regex(pattern);

            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }

        }
    }
}
