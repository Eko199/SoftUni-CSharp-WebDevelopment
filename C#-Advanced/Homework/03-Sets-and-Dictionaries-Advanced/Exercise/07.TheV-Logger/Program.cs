using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    internal class Program
    {
        class VloggerStats
        {
            public VloggerStats()
            {
                Followers = new SortedSet<string>();
            }

            public SortedSet<string> Followers { get; set; }
            public int Following { get; set; } = 0;
        }

        static void Main(string[] args)
        {
            var vloggers = new Dictionary<string, VloggerStats>();

            string input = Console.ReadLine();
            while (input != "Statistics")
            {
                string[] tokens = input.Split();

                if (string.Join(' ', tokens.Skip(1)) == "joined The V-Logger" && !vloggers.ContainsKey(tokens[0]))
                {
                    vloggers.Add(tokens[0], new VloggerStats());
                }
                else if (tokens[1] == "followed" && vloggers.ContainsKey(tokens[0]) &&
                         vloggers.ContainsKey(tokens[2]) && tokens[0] != tokens[2] &&
                         !vloggers[tokens[2]].Followers.Contains(tokens[0]))
                {
                    vloggers[tokens[2]].Followers.Add(tokens[0]);
                    vloggers[tokens[0]].Following++;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            int counter = 0;
            foreach (KeyValuePair<string, VloggerStats> vlogger in vloggers
                         .OrderByDescending(vlogger => vlogger.Value.Followers.Count)
                         .ThenBy(vlogger => vlogger.Value.Following))
            {
                Console.WriteLine($"{++counter}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, " +
                                  $"{vlogger.Value.Following} following");

                if (counter == 1)
                {
                    Console.WriteLine(string.Join(Environment.NewLine,
                        vlogger.Value.Followers.Select(follower => "*  " + follower)));
                }
            }
        }
    }
}
