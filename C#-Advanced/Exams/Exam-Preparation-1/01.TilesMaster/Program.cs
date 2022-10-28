using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var whiteTiles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var greyTiles = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            var areaLocation = new Dictionary<int, string>
            {
                { 40, "Sink" },
                { 50, "Oven" },
                { 60, "Countertop"},
                { 70, "Wall" }
            };

            var locationsCount = new Dictionary<string, int>
            {
                { "Sink", 0 },
                { "Oven", 0 },
                { "Countertop", 0},
                { "Wall", 0 },
                { "Floor", 0 }
            };

            while (whiteTiles.Any() && greyTiles.Any())
            {
                int currWhite = whiteTiles.Pop();
                int currGrey = greyTiles.Dequeue();

                if (currWhite == currGrey)
                {
                    int newTile = currWhite + currGrey;
                    locationsCount[areaLocation.ContainsKey(newTile) ? areaLocation[newTile] : "Floor"]++;
                }
                else
                {
                    whiteTiles.Push(currWhite / 2);
                    greyTiles.Enqueue(currGrey);
                }
            }

            Console.WriteLine($"White tiles left: {(whiteTiles.Any() ? string.Join(", ", whiteTiles) : "none")}");
            Console.WriteLine($"Grey tiles left: {(greyTiles.Any() ? string.Join(", ", greyTiles) : "none")}");

            foreach (var locationCount in locationsCount
                         .Where(loc => loc.Value > 0)
                         .OrderByDescending(loc => loc.Value)
                         .ThenBy(loc => loc.Key))
            {
                Console.WriteLine($"{locationCount.Key}: {locationCount.Value}");
            }
        }
    }
}
