using System;

namespace _05.FootballTeamGenerator
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public int Endurance
        {
            get => endurance;
            private init
            {
                if (IsStatInvalid(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidStatMessage, nameof(Endurance)));

                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint;
            private init
            {
                if (IsStatInvalid(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidStatMessage, nameof(Sprint)));

                sprint = value;
            }
        }

        public int Dribble
        {
            get => dribble;
            private init
            {
                if (IsStatInvalid(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidStatMessage, nameof(Dribble)));

                dribble = value;
            }
        }

        public int Passing
        {
            get => passing;
            private init
            {
                if (IsStatInvalid(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidStatMessage, nameof(Passing)));

                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;
            private init
            {
                if (IsStatInvalid(value))
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidStatMessage, nameof(Shooting)));

                shooting = value;
            }
        }

        private static bool IsStatInvalid(int value) => value < 0 || value > 100;

        public double Average() => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;
    }
}
