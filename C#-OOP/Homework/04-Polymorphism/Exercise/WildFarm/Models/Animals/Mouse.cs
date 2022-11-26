namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Food;

    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion) { }

        protected override IReadOnlySet<Type> EdibleFood 
            => new HashSet<Type> { typeof(Vegetable), typeof(Fruit) };

        protected override double WeightGain => 0.1;

        public override string AskForFood() => "Squeak";

        public override string ToString() => base.ToString() + $", {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
