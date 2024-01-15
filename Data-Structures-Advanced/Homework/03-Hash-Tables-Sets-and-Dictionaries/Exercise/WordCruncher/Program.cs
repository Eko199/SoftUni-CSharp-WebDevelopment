using System;
using System.Collections.Generic;
using System.Linq;

namespace WordCruncher
{
    class Program
    {
        static void Main()
        {
            string[] tokens = Console.ReadLine()!.Split(", ").ToArray();
            string target = Console.ReadLine();

            var combinations = new HashSet<string>();
            GetAllCombinations(tokens, target, new List<string>(), combinations);

            foreach (string combination in combinations)
            {
                Console.WriteLine(combination);
            }
        }

        private static void GetAllCombinations(IReadOnlyList<string> tokens, string target, IList<string> currentPath, ISet<string> result)
        {
            if (string.IsNullOrEmpty(target))
            {
                result.Add(string.Join(' ', currentPath));
            }

            for (int i = 0; i < tokens.Count(); ++i)
            {
                if (!target.StartsWith(tokens[i]))
                {
                    continue;
                }

                currentPath.Add(tokens[i]);
                GetAllCombinations(tokens.Where((_, index) => index != i).ToArray(), target[tokens[i].Length..], currentPath, result);
                currentPath.RemoveAt(currentPath.Count - 1);
            }
        }
    }
}
