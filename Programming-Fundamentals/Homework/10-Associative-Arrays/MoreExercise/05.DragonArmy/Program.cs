using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DragonArmy
{
    class DragonStats
    {
        public const int DefaultDamage = 45;
        public const int DefaultHealth = 250;
        public const int DefaultArmor = 10;

        public DragonStats(int damage, int health, int armor)
        {
            Damage = damage;
            Health = health;
            Armor = armor;
        }

        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var dragonsByType = new Dictionary<string, Dictionary<string, DragonStats>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] dragonData = Console.ReadLine().Split();

                string type = dragonData[0];
                string name = dragonData[1];
                int damage = dragonData[2] == "null" ? DragonStats.DefaultDamage : int.Parse(dragonData[2]);
                int health = dragonData[3] == "null" ? DragonStats.DefaultHealth : int.Parse(dragonData[3]);
                int armor = dragonData[4] == "null" ? DragonStats.DefaultArmor : int.Parse(dragonData[4]);

                var dragonStats = new DragonStats(damage, health, armor);

                if (!dragonsByType.ContainsKey(type))
                    dragonsByType.Add(type, new Dictionary<string, DragonStats> { { name, dragonStats } });
                else
                    dragonsByType[type][name] = dragonStats;
            }

            foreach (var (type, dragons) in dragonsByType)
            {
                double averageDamage = dragons.Select(dragon => dragon.Value.Damage).Average();
                double averageHealth = dragons.Select(dragon => dragon.Value.Health).Average();
                double averageArmor = dragons.Select(dragon => dragon.Value.Armor).Average();

                Console.WriteLine($"{type}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");

                foreach ((string name, DragonStats stats) in dragons.OrderBy(dragon => dragon.Key))
                {
                    Console.WriteLine($"-{name} -> damage: {stats.Damage}, health: {stats.Health}, armor: {stats.Armor}");
                }
            }
        }
    }
}
