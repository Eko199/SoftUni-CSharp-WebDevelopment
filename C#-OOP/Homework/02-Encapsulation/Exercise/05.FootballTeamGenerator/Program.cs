using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var teams = new List<Team>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split(';');
                string teamName = cmdArgs[1];

                try
                {
                    switch (cmdArgs[0])
                    {
                        case "Team":
                            teams.Add(new Team(teamName));
                            break;
                        case "Add":
                            if (teams.All(t => t.Name != teamName))
                                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTeamMessage,
                                    teamName));
                            
                            teams.Single(t => t.Name == teamName)
                                .AddPlayer(new Player(cmdArgs[2], 
                                    int.Parse(cmdArgs[3]), 
                                    int.Parse(cmdArgs[4]), 
                                    int.Parse(cmdArgs[5]), 
                                    int.Parse(cmdArgs[6]), 
                                    int.Parse(cmdArgs[7])));
                            break;
                        case "Remove":
                            if (teams.All(t => t.Name != teamName))
                                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTeamMessage,
                                    teamName));

                            teams.Single(t => t.Name == teamName)
                                .RemovePlayer(cmdArgs[2]);
                            break;
                        case "Rating":
                            if (teams.All(t => t.Name != teamName))
                                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTeamMessage,
                                    teamName));

                            Console.WriteLine($"{teamName} - {teams.Single(t => t.Name == teamName).Rating}");
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }
    }
}
