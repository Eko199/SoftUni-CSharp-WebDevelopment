namespace ChristmasPastryShop.Models.Booths
{
    using System;
    using System.Text;
    using Cocktails.Contracts;
    using Contracts;
    using Delicacies.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;

    public class Booth : IBooth
    {
        private int capacity;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            DelicacyMenu = new DelicacyRepository();
            CocktailMenu = new CocktailRepository();
            CurrentBill = 0;
            Turnover = 0;
            IsReserved = false;
        }

        public int BoothId { get; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);

                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu { get; }
        public IRepository<ICocktail> CocktailMenu { get; }
        public double CurrentBill { get; private set; }
        public double Turnover { get; private set; }
        public bool IsReserved { get; private set; }

        public void UpdateCurrentBill(double amount) => CurrentBill += amount;

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void ChangeStatus() => IsReserved = !IsReserved;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"Booth: {BoothId}" + Environment.NewLine +
                                                 $"Capacity: {Capacity}" + Environment.NewLine +
                                                 $"Turnover: {Turnover:F2} lv" + Environment.NewLine);

            sb.AppendLine("-Cocktail menu:");
            foreach (ICocktail cocktail in CocktailMenu.Models)
            {
                sb.AppendLine($"--{cocktail}");
            }

            sb.AppendLine("-Delicacy menu:");
            foreach (IDelicacy delicacy in DelicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy}");
            }

            return sb.ToString().Trim();
        }
    }
}