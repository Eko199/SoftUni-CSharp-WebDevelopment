using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TeamworkProjects
{
    class Team
    {
        public string Creator { get; set; }
        public string Name { get; set; }
        public List<string> Members { get; set; }

        public Team(string creator, string name)
        {
            Creator = creator;
            Name = name;
            Members = new List<string> { creator };
        }

        public override string ToString() =>
            $"{Name}\n" +
            $"- {Creator}\n" +
             "-- " + string.Join("\n-- ", Members.GetRange(1, Members.Count - 1).OrderBy(member => member));
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>(count);

            for (int i = 0; i < count; i++)
            {
                string[] teamInfo = Console.ReadLine().Split('-');
                string creator = teamInfo[0], teamName = teamInfo[1];

                if (teams.Exists(team => team.Name.Equals(teamName)))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (teams.Exists(team => team.Creator.Equals(creator)))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                teams.Add(new Team(creator, teamName));
                Console.WriteLine($"Team {teamName} has been created by {creator}!");
            }

            string[] tokens = Console.ReadLine().Split("->");
            while (!tokens[0].Equals("end of assignment"))
            {
                string user = tokens[0], teamName = tokens[1];

                if (teams.Exists(team => team.Name.Equals(teamName)) &&
                    !teams.Exists(team => team.Members.Contains(user)))
                {
                    teams.Find(team => team.Name.Equals(teamName)).Members.Add(user);
                }
                else if (!teams.Exists(team => team.Name.Equals(teamName)))
                    Console.WriteLine($"Team {teamName} does not exist!");
                else
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");

                tokens = Console.ReadLine().Split("->");
            }

            List<Team> disbandedTeams = teams.Where(team => team.Members.Count <= 1).OrderBy(team => team.Name).ToList();
            teams.RemoveAll(team => team.Members.Count <= 1);

            teams.OrderByDescending(team => team.Members.Count).ThenBy(team => team.Name).ToList().ForEach(Console.WriteLine);

            Console.WriteLine("Teams to disband:");
            Console.WriteLine(string.Join(Environment.NewLine, disbandedTeams.Select(team => team.Name)));
        }
    }
}
