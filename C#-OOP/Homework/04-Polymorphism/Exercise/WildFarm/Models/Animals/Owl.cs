namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Food;

    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize) { }

        protected override IReadOnlySet<Type> EdibleFood => new HashSet<Type> { typeof(Meat) };
        protected override double WeightGain => 0.25;

        public override string AskForFood() => "Hoot Hoot";
    }
}
