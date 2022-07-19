using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Snowwhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dwarfs = new Dictionary<(string, string), int>();

            string input = Console.ReadLine();
            while (input != "Once upon a time")
            {
                string[] tokens = input.Split(" <:> ");
                string name = tokens[0];
                string hatColor = tokens[1];
                int physics = int.Parse(tokens[2]);

                if (!dwarfs.ContainsKey((name, hatColor)) || dwarfs[(name, hatColor)] < physics)
                    dwarfs[(name, hatColor)] = physics;

                input = Console.ReadLine();
            }

            var hatColors = new Dictionary<string, int>();
            foreach (var dwarf in dwarfs)
            {
                if (!hatColors.ContainsKey(dwarf.Key.Item2))
                    hatColors.Add(dwarf.Key.Item2, 1);
                else
                    hatColors[dwarf.Key.Item2]++;
            }

            foreach (var dwarf in dwarfs
                         .OrderByDescending(dwarf => dwarf.Value)
                         .ThenByDescending(dwarf => hatColors[dwarf.Key.Item2]))
            {
                Console.WriteLine($"({dwarf.Key.Item2}) {dwarf.Key.Item1} <-> {dwarf.Value}");
            }
        }
    }
}
