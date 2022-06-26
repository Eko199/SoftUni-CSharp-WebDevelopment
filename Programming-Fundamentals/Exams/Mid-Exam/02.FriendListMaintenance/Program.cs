using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.FriendListMaintenance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> usernames = Console.ReadLine().Split(", ").ToList();
            string command = Console.ReadLine();

            int blacklistedCount = 0, lostCount = 0;
            while (!command.Equals("Report"))
            {
                string[] tokens = command.Split(" ");

                switch (tokens[0])
                {
                    case "Blacklist":
                        if (usernames.Contains(tokens[1]))
                        {
                            Console.WriteLine($"{tokens[1]} was blacklisted.");
                            usernames[usernames.IndexOf(tokens[1])] = "Blacklisted";
                            blacklistedCount++;
                        }
                        else
                            Console.WriteLine($"{tokens[1]} was not found.");
                        break;
                    case "Error":
                        int index1 = int.Parse(tokens[1]);
                        if (IsIndexValid(index1, usernames) && usernames[index1] != "Blacklisted" &&
                            usernames[index1] != "Lost")
                        {
                            Console.WriteLine($"{usernames[index1]} was lost due to an error.");
                            usernames[index1] = "Lost";
                            lostCount++;
                        }
                        break;
                    case "Change":
                        int index2 = int.Parse(tokens[1]);
                        if (IsIndexValid(index2, usernames))
                        {
                            Console.WriteLine($"{usernames[index2]} changed his username to {tokens[2]}.");
                            usernames[index2] = tokens[2];
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Blacklisted names: {blacklistedCount}");
            Console.WriteLine($"Lost names: {lostCount}");
            Console.WriteLine(string.Join(' ', usernames));
        }

        private static bool IsIndexValid(int index, ICollection<string> list) => index >= 0 && index < list.Count;
    }
}
