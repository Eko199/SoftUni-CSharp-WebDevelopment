namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Food;

    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed) { }

        protected override IReadOnlySet<Type> EdibleFood
            => new HashSet<Type> { typeof(Vegetable), typeof(Meat) };

        protected override double WeightGain => 0.3;

        public override string AskForFood() => "Meow";
    }
}
