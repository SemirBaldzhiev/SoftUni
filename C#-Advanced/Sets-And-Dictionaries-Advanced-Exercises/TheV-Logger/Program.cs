using System;
using System.Collections.Generic;
using System.Linq;

namespace TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> vloggersInfo = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Statistics")
                {
                    break;
                }

                string[] commands = line.Split(" ").ToArray();
                string vloggerName = commands[0];

                if (commands[1] == "joined")
                {
                    if (!vloggersInfo.ContainsKey(vloggerName))
                    {
                        vloggersInfo.Add(vloggerName, new Dictionary<string, SortedSet<string>>());
                        vloggersInfo[vloggerName].Add("following", new SortedSet<string>());
                        vloggersInfo[vloggerName].Add("followers", new SortedSet<string>());
                    }
                }
                else if (commands[1] == "followed")
                {
                    string firstVloggerName = commands[0];
                    string secondVloggerName = commands[2];

                    bool isNotSameNames = firstVloggerName != secondVloggerName;

                    if (vloggersInfo.ContainsKey(firstVloggerName) && vloggersInfo.ContainsKey(secondVloggerName) && isNotSameNames)
                    {
                        vloggersInfo[secondVloggerName]["followers"].Add(firstVloggerName);
                        vloggersInfo[firstVloggerName]["following"].Add(secondVloggerName);
                    }
                }

            }

            var sortedVloggersData = vloggersInfo
                .OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(x => x.Value["following"].Count)
                .ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine($"The V-Logger has a total of {vloggersInfo.Count} vloggers in its logs.");
            int counter = 0;

            foreach (var vlogger in sortedVloggersData)
            {
                int followersCount = vlogger.Value["followers"].Count;
                int followingsCount = vlogger.Value["following"].Count;

                Console.WriteLine($"{++counter}. {vlogger.Key} : {followersCount} followers, {followingsCount} following");

                if (counter == 1)
                {
                    foreach (var follower in vlogger.Value["followers"])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }
        }
    }
}
