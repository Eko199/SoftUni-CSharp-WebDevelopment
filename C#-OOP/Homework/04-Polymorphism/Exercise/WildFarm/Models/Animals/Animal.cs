namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Food;

    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public string Name { get; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }
        protected abstract IReadOnlySet<Type> EdibleFood { get; }
        protected abstract double WeightGain { get; }

        public abstract string AskForFood();

        public void Eat(Food food)
        {
            if (!EdibleFood.Contains(food.GetType()))
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");

            Weight += WeightGain * food.Quantity;
            FoodEaten += food.Quantity;
        }

        public override string ToString() => $"{GetType().Name} [{Name}";
    }
}
