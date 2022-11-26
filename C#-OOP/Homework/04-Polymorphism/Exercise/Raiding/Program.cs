namespace Raiding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Factories;
    using Models;

    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var heroes = new List<BaseHero>(n);
            var heroFactory = new HeroFactory();

            for (int i = 0; i < n; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    heroes.Add(heroFactory.CreateHero(heroType, heroName));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    i--;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (BaseHero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            Console.WriteLine(heroes.Sum(h => h.Power) >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}
