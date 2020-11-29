using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04._StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@([A-Za-z]+)[^@\-!:>]*:(\d+)[^@\-!:>]*!(A|D)![^@\-!:>]*->(\d+)";
            int n = int.Parse(Console.ReadLine());

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();


            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();

                int count = message.Count(x => (x == 's' || x == 't' || x == 'a' || x == 'r' || x == 'S' || x == 'T' || x == 'A' || x == 'R'));

                List<char> newMessage = message.Select(x => (char)(x + count)).ToList();
                StringBuilder decryptedMessage = new StringBuilder();

                for (int j = 0; j < message.Length; j++)
                {
                    decryptedMessage.Append((char)(message[j] - count));
                }

                

                var match = regex.Match(decryptedMessage.ToString());

                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    int population = int.Parse(match.Groups[2].Value);
                    string attackType = match.Groups[3].Value;
                    int soldierCount = int.Parse(match.Groups[4].Value);

                    if (attackType == "A")
                    {
                        attackedPlanets.Add(name);
                    }
                    else
                    {
                        destroyedPlanets.Add(name);
                    }

                }

            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count()}");
            foreach (var planet in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count()}");

            foreach (var planet in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
