using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var clothes = new Dictionary<string, Dictionary<string, int>>(count);

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split(" -> ");

                if (!clothes.ContainsKey(tokens[0]))
                    clothes.Add(tokens[0], new Dictionary<string, int>());

                tokens[1].Split(',').ToList().ForEach(clothing =>
                {
                    if (!clothes[tokens[0]].ContainsKey(clothing))
                        clothes[tokens[0]].Add(clothing, 0);
                    clothes[tokens[0]][clothing]++;
                });
            }

            string[] searchedDress = Console.ReadLine().Split();
            foreach ((string color, Dictionary<string, int> clothesCount) in clothes)
            {
                Console.WriteLine(color + " clothes:");
                foreach (var clothingCount in clothesCount)
                {
                    Console.WriteLine($"* {clothingCount.Key} - {clothingCount.Value}{(color == searchedDress[0] && clothingCount.Key == searchedDress[1] ? " (found!)" : string.Empty)}");
                }
            }
        }
    }
}
