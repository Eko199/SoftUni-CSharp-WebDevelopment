using System;
using System.Collections.Generic;

namespace _04.SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var registered = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                switch (tokens[0])
                {
                    case "register":
                        if (registered.ContainsKey(tokens[1]))
                            Console.WriteLine($"ERROR: already registered with plate number {registered[tokens[1]]}");
                        else
                        {
                            registered.Add(tokens[1], tokens[2]);
                            Console.WriteLine($"{tokens[1]} registered {tokens[2]} successfully");
                        }
                        break;
                    case "unregister":
                        if (!registered.ContainsKey(tokens[1]))
                            Console.WriteLine($"ERROR: user {tokens[1]} not found");
                        else
                        {
                            registered.Remove(tokens[1]);
                            Console.WriteLine($"{tokens[1]} unregistered successfully");
                        }
                        break;
                }
            }

            foreach (var userCar in registered)
            {
                Console.WriteLine(userCar.Key + " => " + userCar.Value);
            }
        }
    }
}
