namespace Formula1.Models
{
    using System;

    using Contracts;
    using Utilities;

    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;

        public Pilot(string fullName)
        {
            FullName = fullName;
            CanRace = false;
            NumberOfWins = 0;
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));

                fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get => car;
            private set => car = value ?? throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
        }

        public int NumberOfWins { get; private set; }
        public bool CanRace { get; private set; }

        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            CanRace = true;
        }

        public void WinRace() => NumberOfWins++;

        public override string ToString() => $"Pilot {FullName} has {NumberOfWins} wins.";
    }
}