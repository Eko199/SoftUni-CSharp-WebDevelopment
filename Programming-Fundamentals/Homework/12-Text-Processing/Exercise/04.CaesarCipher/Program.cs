using System;
using System.Linq;

namespace _04.CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Console.ReadLine().Select(c => (char) (c + 3)).ToArray());
        }
    }
}
