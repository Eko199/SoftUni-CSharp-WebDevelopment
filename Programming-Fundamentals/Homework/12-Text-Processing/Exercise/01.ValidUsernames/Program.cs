using System;
using System.Linq;

namespace _01.ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");

            foreach (string username in usernames)
            {
                if (3 <= username.Length && username.Length <= 16 && !username.Any(c => !char.IsLetterOrDigit(c) && c != '-' && c != '_'))
                    Console.WriteLine(username);
            }
        }
    }
}
