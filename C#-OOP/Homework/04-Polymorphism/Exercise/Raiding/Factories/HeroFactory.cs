namespace Raiding.Factories
{
    using System;

    using Models;

    public class HeroFactory
    {
        public BaseHero CreateHero(string type, string name)
            => type switch
            {
                "Druid" => new Druid(name),
                "Paladin" => new Paladin(name),
                "Rogue" => new Rogue(name),
                "Warrior" => new Warrior(name),
                _ => throw new ArgumentException("Invalid hero!")
            };
    }
}
