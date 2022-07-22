using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var furniture = new List<string>();
            double totalPrice = 0;

            string input = Console.ReadLine();
            while (input != "Purchase")
            {
                Match match = Regex.Match(input, @"^>>(?<furniture>[A-Za-z]+?)<<(?<price>[0-9]+(\.[0-9]+)?)!(?<quantity>[0-9]+)\b");

                if (match.Success)
                {
                    furniture.Add(match.Groups["furniture"].Value);
                    totalPrice += double.Parse(match.Groups["price"].Value) * int.Parse(match.Groups["quantity"].Value);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            furniture.ForEach(Console.WriteLine);
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
