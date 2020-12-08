using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _08._MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([@|#])([A-Za-z]{3,})\1{2}([A-Za-z]{3,})\1";
            
            string text = Console.ReadLine();

            Regex regex = new Regex(pattern);
            var matches = regex.Matches(text);
            List<string> mirrorWords = new List<string>();

            foreach (Match match in matches)
            {
                string firstWord = match.Groups[2].Value;
                string firstWordRev = new string(firstWord.ToCharArray().Reverse().ToArray());
                string secondWord = match.Groups[3].Value;

                if (firstWordRev == secondWord)
                {
                    mirrorWords.Add($"{firstWord} <=> {secondWord}");
                }
                else
                {

                }
            }

            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }

            if (mirrorWords.Count > 0)
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrorWords));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }
        }
    }
}
