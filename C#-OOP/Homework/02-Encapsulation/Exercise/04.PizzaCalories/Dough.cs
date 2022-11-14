using System;
using System.Collections.Generic;

namespace _04.PizzaCalories
{
    public class Dough : Ingredient
    {
        private static readonly Dictionary<string, double> Modifiers = new Dictionary<string, double>
        {
            { "white", 1.5 },
            { "wholegrain", 1.0 },
            { "crispy", 0.9 },
            { "chewy", 1.1 },
            { "homemade", 1.0 }
        };

        private string flourType;
        private string bakingTechnique;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        private string FlourType
        {
            get => flourType;
            init
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                    throw new ArgumentException(ExceptionMessages.InvalidDoughTypeMessage);

                flourType = value;
            }
        }

        private string BakingTechnique
        {
            get => bakingTechnique;
            init
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                    throw new ArgumentException(ExceptionMessages.InvalidDoughTypeMessage);

                bakingTechnique = value;
            }
        }

        protected override double Weight
        {
            get => base.Weight;
            init
            {
                if (value < 0 || value > 200)
                    throw new ArgumentException(ExceptionMessages.InvalidDoughWeightMessage);

                base.Weight = value;
            }
        }

        public override double Calories()
            => base.Calories() * Modifiers[FlourType.ToLower()] * Modifiers[BakingTechnique.ToLower()];
    }
}
