using System;
using System.Collections.Generic;

namespace _04.MorseCodeTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var morseCode = new Dictionary<string, char>
            {
                { ".-", 'A' },
                { "-...", 'B' },
                { "-.-.", 'C' },
                { "-..", 'D' },
                { ".", 'E' },
                { "..-.", 'F' },
                { "--.", 'G' },
                { "....", 'H' },
                { "..", 'I' },
                { ".---", 'J' },
                { "-.-", 'K' },
                { ".-..", 'L' },
                { "--", 'M' },
                { "-.", 'N' },
                { "---", 'O' },
                { ".--.", 'P' },
                { "--.-", 'Q' },
                { ".-.", 'R' },
                { "...", 'S' },
                { "-", 'T' },
                { "..-", 'U' },
                { "...-", 'V' },
                { ".--", 'W' },
                { "-..-", 'X' },
                { "-.--", 'Y' },
                { "--..", 'Z' }
            };

            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string letter in input)
            {
                Console.Write(letter == "|" ? ' ' : morseCode[letter]);
            }
        }
    }
}
