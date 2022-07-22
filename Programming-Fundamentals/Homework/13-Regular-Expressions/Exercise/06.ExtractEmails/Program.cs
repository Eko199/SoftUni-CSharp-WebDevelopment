using System;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MatchCollection emails = Regex.Matches(Console.ReadLine(),
                @"\s[A-Za-z\d][\w.\-]*[A-Za-z\d]@[A-Za-z][A-Za-z\-]*[A-Za-z](\.[A-Za-z][A-Za-z\-]*[A-Za-z])+\b");

            foreach (Match email in emails)
            {
                Console.WriteLine(email.Value.Trim());
            }
        }
    }
}
