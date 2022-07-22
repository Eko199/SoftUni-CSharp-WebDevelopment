using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] demons = Regex.Split(Console.ReadLine(), @", *")
                .Where(demon => demon != string.Empty)
                .Select(demon => demon.Trim())
                .ToArray();

            foreach (string demon in demons.OrderBy(demon => demon))
            {
                int health = demon.Where(c => !Regex.IsMatch(c.ToString(), @"[0-9+\-*/.]")).Sum(c => c);
                double damage = 0;

                MatchCollection numbers = Regex.Matches(demon, @"[+\-]?\d+(\.\d+)?");
                foreach (Match number in numbers)
                {
                    damage += double.Parse(number.Value);
                }

                damage *= Math.Pow(2, demon.Count(c => c == '*') - demon.Count(c => c == '/'));

                Console.WriteLine($"{demon} - {health} health, {damage:f2} damage");
            }
        }
    }
}
