namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Food;

    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize) { }

        protected override IReadOnlySet<Type> EdibleFood 
            => new HashSet<Type> { typeof(Fruit), typeof(Meat), typeof(Seeds), typeof(Vegetable) };
        protected override double WeightGain => 0.35;

        public override string AskForFood() => "Cluck";
    }
}
