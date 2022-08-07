using System;
using System.Collections.Generic;

namespace _03.DegustationParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var guestLikes = new Dictionary<string, List<string>>();
            int unlikedMeals = 0;

            string command = Console.ReadLine();
            while (command != "Stop")
            {
                string[] tokens = command.Split('-');
                string action = tokens[0], guest = tokens[1], meal = tokens[2];

                switch (action)
                {
                    case "Like":
                        if (!guestLikes.ContainsKey(guest))
                            guestLikes.Add(guest, new List<string>());
                        if (!guestLikes[guest].Contains(meal))
                            guestLikes[guest].Add(meal);
                        break;
                    case "Dislike":
                        if (!guestLikes.ContainsKey(guest))
                        {
                            Console.WriteLine($"{guest} is not at the party.");
                            break;
                        }

                        if (!guestLikes[guest].Contains(meal))
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                            break;
                        }

                        if (guestLikes[guest].Remove(meal))
                        {
                            unlikedMeals++;
                            Console.WriteLine($"{guest} doesn't like the {meal}.");
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            foreach (var (guest, meals) in guestLikes)
            {
                Console.WriteLine(guest + ": " + string.Join(", ", meals));
            }

            Console.WriteLine("Unliked meals: " + unlikedMeals);
        }
    }
}
