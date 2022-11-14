using System;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private string name;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Stats = new Stats(endurance, sprint, dribble, passing, shooting);
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

        public Stats Stats { get; }

        public double Skill => Stats.Average();
    }
}
