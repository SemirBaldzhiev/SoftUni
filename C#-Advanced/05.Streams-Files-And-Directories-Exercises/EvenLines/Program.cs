using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[-,.!?]";

            using StreamReader reader = new StreamReader("text.txt");
            int counter = 0;
            string line = reader.ReadLine();
            
            while (line != null)
            {
                if (counter++ % 2 == 0)
                {
                    string replacedLine = Regex.Replace(line, pattern, "@");

                    string[] words = replacedLine
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    Console.WriteLine(string.Join(" ", words.Reverse()));
                }

                line = reader.ReadLine();
            }
        }
    }
}
