namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Food;

    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion) { }

        protected override IReadOnlySet<Type> EdibleFood => new HashSet<Type> { typeof(Meat) };
        protected override double WeightGain => 0.4;

        public override string AskForFood() => "Woof!";

        public override string ToString() => base.ToString() + $", {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
