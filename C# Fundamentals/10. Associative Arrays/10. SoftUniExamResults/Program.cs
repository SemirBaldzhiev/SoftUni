using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> examResults = new Dictionary<string, int>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "exam finished")
                {
                    break;
                }

                string[] tokens = input
                    .Split('-', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string username = tokens[0];

                if (tokens[1] == "banned")
                {
                    examResults.Remove(username);
                    continue;
                }

                string language = tokens[1];
                int points = int.Parse(tokens[2]);

                if (!examResults.ContainsKey(username))
                {
                    examResults.Add(username, points);
                }
                else
                {
                    if (examResults[username] < points)
                    {
                        examResults[username] = points;
                    }
                }

                if (submissions.ContainsKey(language))
                {
                    submissions[language]++;
                }
                else
                {
                    submissions.Add(language, 1);
                }

            }

            Console.WriteLine("Results:");
            foreach (var result in examResults.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{result.Key} | {result.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var submission in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }
        }
    }
}
