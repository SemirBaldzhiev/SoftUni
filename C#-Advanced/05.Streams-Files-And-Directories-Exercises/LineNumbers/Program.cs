using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputFilePath = Path.Combine("..", "..", "..", "output.txt");

            string[] lines = File.ReadAllLines("text.txt");
            List<string> newLines = new List<string>();

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                int lettersCount = 0;
                int punctuationSymbolsCount = 0;

                foreach (var ch in line)
                {
                    if (char.IsLetter(ch))
                    {
                        lettersCount++;

                    }
                    else if (char.IsPunctuation(ch))
                    {
                        punctuationSymbolsCount++;
                    }
                }

                string newLine = $"Line {i + 1}: {line} ({lettersCount})({punctuationSymbolsCount})";
                newLines.Add(newLine);

            }

            Console.WriteLine(string.Join(Environment.NewLine, newLines));
            File.AppendAllLines(outputFilePath, newLines);

        }
    }
}
