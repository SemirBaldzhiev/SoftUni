using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string numPattern = @"\d";
            string emojiPattern = @"(::|\*\*)([A-Z][a-z]{2,})\1";

            string text = Console.ReadLine();

            long coolThreshold = 1;
            List<string> coolEmojis = new List<string>();

            Regex numberRegex = new Regex(numPattern);
            Regex emojiRegex = new Regex(emojiPattern);
            
            var matches = numberRegex.Matches(text);

            foreach (Match match in matches)
            {
                coolThreshold *= long.Parse(match.Value);
            }

            var emojiMatches = emojiRegex.Matches(text);
            
            foreach (Match match in emojiMatches)
            {
                int emojiSum = match.Groups[2].Value.ToCharArray().Sum(x => x);

                if (emojiSum > coolThreshold)
                {
                    coolEmojis.Add(match.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{emojiMatches.Count} emojis found in the text. The cool ones are:");
            
            if (coolEmojis.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, coolEmojis));
            }
            

        }
    }
}
