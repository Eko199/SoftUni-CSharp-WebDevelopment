using System;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Regex.Matches(Console.ReadLine(), @"\+359([- ])2\1\d{3}\1\d{4}\b")));
        }
    }
}
