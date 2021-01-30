using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {

            string expectedResultPath = Path.Combine("..", "..", "..", "expectedResult.txt");
            string[] words = File.ReadAllLines("words.txt");

            Dictionary<string, int> wordsCounts = new Dictionary<string, int>();

            foreach (var word in words)
            {
                wordsCounts.Add(word.ToLower(), 0);
            }

            string text = File.ReadAllText("text.txt").ToLower();

            string[] tetxWords = text
                .Split(new string[] { " ", ",", ".", "!", "?", "-", Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in tetxWords)
            {
                if (wordsCounts.ContainsKey(word))
                {
                    wordsCounts[word]++;
                }
            }

            Dictionary<string, int> sortedWords = wordsCounts
                .OrderByDescending(x => x.Value)
                .ToDictionary(k => k.Key, v => v.Value);

            List<string> outputLines = sortedWords
                .Select(x => $"{x.Key} - {x.Value}").ToList();

            File.WriteAllLines(expectedResultPath, outputLines);
        }
    }
}
