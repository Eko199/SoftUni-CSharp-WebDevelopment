using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MOBAChallenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var players = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "Season end")
            {
                if (input.Contains(" -> "))
                {
                    string[] tokens = input.Split(" -> ");
                    string name = tokens[0];
                    string position = tokens[1];
                    int skill = int.Parse(tokens[2]);

                    if (!players.ContainsKey(name))
                        players.Add(name, new Dictionary<string, int> { { position, skill} });
                    else if (!players[name].ContainsKey(position) || players[name][position] < skill)
                        players[name][position] = skill;
                }
                else
                {
                    string[] duel = input.Split(" vs ");

                    if (players.ContainsKey(duel[0]) && players.ContainsKey(duel[1]) &&
                        players[duel[0]].Keys.Intersect(players[duel[1]].Keys).Any())
                    {
                        string commonPosition = players[duel[0]].Keys.Intersect(players[duel[1]].Keys).First();
                        if (players[duel[0]][commonPosition] > players[duel[1]][commonPosition])
                            players.Remove(duel[1]);
                        else if (players[duel[0]][commonPosition] < players[duel[1]][commonPosition])
                            players.Remove(duel[0]);
                    }
                }

                input = Console.ReadLine();
            }

            foreach ((string name, Dictionary<string, int> skills) in players
                         .OrderByDescending(player => player.Value.Values.Sum())
                         .ThenBy(player => player.Key))
            {
                Console.WriteLine($"{name}: {skills.Values.Sum()} skill");

                foreach (var skill in skills
                             .OrderByDescending(skill => skill.Value)
                             .ThenBy(skill => skill.Key))
                {
                    Console.WriteLine($"- {skill.Key} <::> {skill.Value}");
                }
            }
        }
    }
}
