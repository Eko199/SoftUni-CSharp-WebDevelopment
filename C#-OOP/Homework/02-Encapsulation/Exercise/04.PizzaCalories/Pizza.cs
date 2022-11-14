using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public Pizza(string name, Dough dough) : this(name)
        {
            Dough = dough;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                    throw new ArgumentException(ExceptionMessages.InvalidPizzaNameMessage);

                name = value;
            }
        }

        public Dough Dough
        {
            private get => dough;
            set => dough = value;
        }

        public int ToppingsCount => toppings.Count;
        public double Calories => Dough.Calories() + toppings.Sum(t => t.Calories());

        public void AddTopping(Topping topping)
        {
            if (ToppingsCount == 10)
                throw new ArgumentException(ExceptionMessages.InvalidPizzaToppingsCountMessage);

            toppings.Add(topping);
        }

        public override string ToString()
            => $"{Name} - {Calories:F2} Calories.";
    }
}
