using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of contests")
                {
                    break;
                }

                string[] contestData = input.Split(":").ToArray();

                string contest = contestData[0];
                string contestPassword = contestData[1];

                contests.Add(contest, contestPassword);
            }

            SortedDictionary<string, Dictionary<string, int>> submissions = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end of submissions")
                {
                    break;
                }

                string[] submissionData = line.Split("=>").ToArray();

                string contest = submissionData[0];
                string password = submissionData[1];
                string username = submissionData[2];
                int points = int.Parse(submissionData[3]);

                bool isValidContest = contests.ContainsKey(contest);

                if (isValidContest && contests[contest] == password)
                {
                    if (!submissions.ContainsKey(username))
                    {
                        submissions.Add(username, new Dictionary<string, int>());
                    }

                    if (!submissions[username].ContainsKey(contest))
                    {
                        submissions[username].Add(contest, points);
                    }
                    else
                    {
                        if (points > submissions[username][contest])
                        {
                            submissions[username][contest] = points;
                        }
                    }
                }

            }

            var bestCandidate = submissions.OrderByDescending(x => x.Value.Values.Sum()).FirstOrDefault();
            int totalPoints = bestCandidate.Value.Values.Sum();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {totalPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var submission in submissions)
            {
                Console.WriteLine($"{submission.Key}");

                foreach (var contest in submission.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
