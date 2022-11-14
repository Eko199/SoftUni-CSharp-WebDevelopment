using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidNameMessage);

                name = value;
            }
        }

        public int Rating => (int)Math.Round(players.Sum(p => p.Skill));

        public void AddPlayer(Player player) => players.Add(player);

        public void RemovePlayer(string playerName)
        {
            if (players.All(p => p.Name != playerName))
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InvalidPlayerMessage, playerName, Name));

            players.RemoveAll(p => p.Name == playerName);
        }
    }
}
