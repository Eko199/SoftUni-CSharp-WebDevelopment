using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.SntaSecretHelp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            while (input != "end")
            {
                Match match = Regex.Match(
                    new string(input.Select(c => (char)(c - key)).ToArray()),
                    @"[^@\-!:>]*@(?<name>[A-Za-z]+)[^@\-!:>]*!(?<behaviour>[GN])!");

                if (match.Success && match.Groups["behaviour"].Value == "G")
                    Console.WriteLine(match.Groups["name"]);

                input = Console.ReadLine();
            }
        }
    }
}
