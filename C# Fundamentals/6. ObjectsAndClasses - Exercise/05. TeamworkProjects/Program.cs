using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < teamsCount; i++)
            {
                string[] inputTeam = Console.ReadLine().Split('-').ToArray();

                
                if (teams.Select(x => x.Creator).Contains(inputTeam[0]))
                {
                    Console.WriteLine($"{inputTeam[0]} cannot create another team!");
                    continue;
                }
                if (teams.Select(x => x.Name).Contains(inputTeam[1]))
                {
                    Console.WriteLine($"Team {inputTeam[1]} was already created!");
                    continue;
                }

                Team team = new Team(inputTeam[0], inputTeam[1], new List<string>());
                
                teams.Add(team);

                Console.WriteLine($"Team {team.Name} has been created by {team.Creator}!");
            }

            string line = Console.ReadLine();

            while (line != "end of assignment")
            {
                string[] commands = line.Split("->").ToArray();

                if (!teams.Select(x => x.Name).Contains(commands[1]))
                {
                    Console.WriteLine($"Team {commands[1]} does not exist!");
                    line = Console.ReadLine();
                    continue;
                }
                if (teams.Select(x => x.Creator).Contains(commands[0]) || teams.Select(x => x.Members).Any(x => x.Contains(commands[0])))
                {
                    Console.WriteLine($"Member {commands[0]} cannot join team {commands[1]}!");
                    line = Console.ReadLine();
                    continue;
                }

                Team teamToAddMember = teams.Where(x => x.Name == commands[1]).FirstOrDefault();

                teamToAddMember.Members.Add(commands[0]);

                line = Console.ReadLine();
            }

            List<Team> teamsToDisband = teams.Where(x => x.Members.Count == 0).ToList();

            foreach (var team in teams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.Name))
            {
                if (team.Members.Count != 0)
                {
                    Console.WriteLine(team.Name);
                    Console.WriteLine($"- {team.Creator}");

                    foreach (var member in team.Members.OrderBy(x => x))
                    {
                        Console.WriteLine($"-- {member}");
                    }
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (var team in teamsToDisband.OrderBy(x => x.Name))
            {
                Console.WriteLine(team.Name);
            }
        }
    }

    public class Team
    {
        public string Creator { get; set; }
        public string Name { get; set; }
        public List<string> Members { get; set; }


        public Team(string creator, string name, List<string> members)
        {
            Creator = creator;
            Name = name;
            Members = members;
        }

    }
}
