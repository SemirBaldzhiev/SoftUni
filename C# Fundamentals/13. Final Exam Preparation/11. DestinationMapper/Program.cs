using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _11._DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(=|/)([A-Z][A-Za-z]{2,})\1";

            string places = Console.ReadLine();
            List<string> destinations = new List<string>();

            Regex regex = new Regex(pattern);

            var matches = regex.Matches(places);
            int travelPoints = 0;

            foreach (Match match in matches)
            {
                string place = match.Groups[2].Value;
                travelPoints += place.Length;
                destinations.Add(place);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
