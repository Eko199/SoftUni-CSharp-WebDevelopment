using System;

namespace _03.ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
        {
            get => name;
            private init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.EmptyNameMessage);

                name = value;
            }
        }

        public decimal Cost
        {
            get => cost;
            private init
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.NegativeMoneyMessage);

                cost = value;
            }
        }
    }
}
