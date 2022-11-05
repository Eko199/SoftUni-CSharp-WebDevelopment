using System;
using System.Linq;

namespace SetCover
{
    using System.Collections.Generic;
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] universe = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int setsCount = int.Parse(Console.ReadLine());
            int[][] sets = new int[setsCount][];

            for (int i = 0; i < setsCount; i++)
            {
                sets[i] = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            }

            List<int[]> setsToTake = ChooseSets(sets.ToList(), universe.ToList());

            Console.WriteLine($"Sets to take ({setsToTake.Count}):");
            setsToTake.ForEach(set => Console.WriteLine($"{{ {string.Join(", ", set)} }}"));
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            var result = new List<int[]>();

            while (universe.Any())
            {
                int[] optimalSet = sets.MaxBy(set => set.Count(x => universe.Contains(x)));
                result.Add(optimalSet);
                universe = universe.Except(optimalSet).ToArray();
            }

            return result;
        }
    }
}
