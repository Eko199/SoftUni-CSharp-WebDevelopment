namespace WildFarm.Models.Animals
{
    using System;
    using System.Collections.Generic;

    using Food;

    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed) { }

        protected override IReadOnlySet<Type> EdibleFood => new HashSet<Type> { typeof(Meat) };
        protected override double WeightGain => 1;

        public override string AskForFood() => "ROAR!!!";
    }
}
