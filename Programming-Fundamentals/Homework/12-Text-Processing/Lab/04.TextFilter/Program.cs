using System;
using System.Linq;

namespace _04.TextFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            text = bannedWords
                .Aggregate(text, (current, bannedWord) 
                    => current.Replace(bannedWord, new string('*', bannedWord.Length)));

            Console.WriteLine(text);
        }
    }
}
