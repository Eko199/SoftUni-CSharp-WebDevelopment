using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.WinningTicket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Regex.Split(Console.ReadLine(), @" *, +")
                .Where(ticket => ticket != string.Empty)
                .ToArray();

            foreach (string ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                Regex regex = new Regex(@"([@#$^])\1{5,}");
                Match leftMatch = regex.Match(ticket[..(ticket.Length / 2)]);
                Match rightMatch = regex.Match(ticket[(ticket.Length / 2)..]);

                Console.Write($"ticket \"{ticket}\" - ");
                if (leftMatch.Success && rightMatch.Success && leftMatch.Value[0] == rightMatch.Value[0])
                {
                    int matchLength = Math.Min(leftMatch.Value.Length, rightMatch.Value.Length);
                    Console.WriteLine($"{matchLength}{leftMatch.Value[0]}" + (matchLength == 10 ? " Jackpot!" : string.Empty));
                }
                else
                    Console.WriteLine("no match");
            }
        }
    }
}
