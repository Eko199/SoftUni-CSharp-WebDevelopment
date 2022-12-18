namespace INStock
{
    using System;
    using Contracts;

    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;

        public Product(string label, decimal price, int quantity)
        {
            Label = label;
            Price = price;
            Quantity = quantity;
        }

        public string Label
        {
            get => label;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Label can't be null or white space!");

                label = value;
            }
        }

        public decimal Price
        {
            get => price;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Price can't 0 or negative!");

                price = value;
            }
        }

        public int Quantity
        {
            get => quantity;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Quantity can't be negative!");
                
                quantity = value;
            }
        }

        public int CompareTo(IProduct other)
        {
            throw new System.NotImplementedException();
        }
    }
}