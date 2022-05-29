using System;
using System.Linq;

namespace _05.Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string attempt = Console.ReadLine();

            string password = new string (username.Reverse().ToArray());
            int attempts = 0;
            while (attempt != password)
            {
                attempts++;
                if (attempts == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }

                Console.WriteLine("Incorrect password. Try again.");
                attempt = Console.ReadLine();
            }

            if (attempts < 4)
                Console.WriteLine($"User {username} logged in.");
        }
    }
}
