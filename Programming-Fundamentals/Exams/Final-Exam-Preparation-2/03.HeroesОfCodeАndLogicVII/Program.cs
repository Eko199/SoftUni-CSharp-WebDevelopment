using System;
using System.Collections.Generic;

namespace _03.HeroesОfCodeАndLogicVII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MaxHP = 100;
            const int MaxMP = 200;
            var heroes = new Dictionary<string, (int, int)>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] heroInfo = Console.ReadLine().Split();
                heroes.Add(heroInfo[0], (int.Parse(heroInfo[1]), int.Parse(heroInfo[2])));
            }

            string cmd = Console.ReadLine();
            while (cmd != "End")
            {
                string[] tokens = cmd.Split(" - ");
                string hero = tokens[1];
                int amount = int.Parse(tokens[2]);

                switch (tokens[0])
                {
                    case "CastSpell":
                        if (heroes[hero].Item2 >= amount)
                        {
                            heroes[hero] = (heroes[hero].Item1, heroes[hero].Item2 - amount);
                            Console.WriteLine($"{hero} has successfully cast {tokens[3]} and now has {heroes[hero].Item2} MP!");
                        }
                        else
                            Console.WriteLine($"{hero} does not have enough MP to cast {tokens[3]}!");
                        break;
                    case "TakeDamage":
                        heroes[hero] = (heroes[hero].Item1 - amount, heroes[hero].Item2);
                        if (heroes[hero].Item1 <= 0)
                        {
                            heroes.Remove(hero);
                            Console.WriteLine($"{hero} has been killed by {tokens[3]}!");
                        }
                        else
                            Console.WriteLine($"{hero} was hit for {amount} HP by {tokens[3]} and now has {heroes[hero].Item1} HP left!");
                        break;
                    case "Recharge":
                        int oldMP = heroes[hero].Item2;
                        heroes[hero] = (heroes[hero].Item1, Math.Min(MaxMP, heroes[hero].Item2 + amount));
                        Console.WriteLine($"{hero} recharged for {heroes[hero].Item2 - oldMP} MP!");
                        break;
                    case "Heal":
                        int oldHP = heroes[hero].Item1;
                        heroes[hero] = (Math.Min(MaxHP, heroes[hero].Item1 + amount), heroes[hero].Item2);
                        Console.WriteLine($"{hero} healed for {heroes[hero].Item1 - oldHP} HP!");
                        break;
                }

                cmd = Console.ReadLine();
            }

            foreach (var (hero, stats) in heroes)
            {
                Console.WriteLine(hero);
                Console.WriteLine("  HP: " + stats.Item1);
                Console.WriteLine("  MP: " + stats.Item2);
            }
        }
    }
}
