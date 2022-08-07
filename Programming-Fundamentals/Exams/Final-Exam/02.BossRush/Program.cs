using System;
using System.Text.RegularExpressions;

namespace _02.BossRush
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            var regex = new Regex(@"\|(?<name>[A-Z]{4,})\|:#(?<title>[A-Za-z]+ [A-Za-z]+)#");

            for (int i = 0; i < count; i++)
            {
                Match match = regex.Match(Console.ReadLine());
                if (match.Success)
                {
                    Console.WriteLine($"{match.Groups["name"]}, The {match.Groups["title"]}\n" +
                        $">> Strength: {match.Groups["name"].Length}\n" +
                        $">> Armor: {match.Groups["title"].Length}");
                }
                else
                    Console.WriteLine("Access denied!");
            }
        }
    }
}
