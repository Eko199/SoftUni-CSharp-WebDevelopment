using System;
using System.Collections.Generic;

namespace _04.PizzaCalories
{
    public class Topping : Ingredient
    {
        private static readonly Dictionary<string, double> Modifiers = new Dictionary<string, double>
        {
            { "meat", 1.2 },
            { "veggies", 0.8 },
            { "cheese", 1.1 },
            { "sauce", 0.9 }
        }; 
        
        private string type;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }

        private string Type
        {
            get => type;
            init
            {
                if (!Modifiers.ContainsKey(value.ToLower()))
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidToppingTypeMessage, value));

                type = value;
            }
        }

        protected override double Weight
        {
            get => base.Weight;
            init
            {
                if (value < 0 || value > 50)
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidToppingWeightMessage, Type));

                base.Weight = value;
            }
        }

        public override double Calories() => base.Calories() * Modifiers[Type.ToLower()];
    }
}
