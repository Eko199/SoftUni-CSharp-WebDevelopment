using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();
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

        private decimal Money
        {
            get => money;
            set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.NegativeMoneyMessage);

                money = value;
            }
        }

        public string BuyProduct(Product product)
        {
            try
            {
                Money -= product.Cost;
                bagOfProducts.Add(product);
                return $"{Name} bought {product.Name}";
            }
            catch (ArgumentException)
            {
                return $"{Name} can't afford {product.Name}";
            }
        }

        public override string ToString()
            => $"{Name} - {(bagOfProducts.Any() ? string.Join(", ", bagOfProducts.Select(p => p.Name)) : "Nothing bought")}";
    }
}
