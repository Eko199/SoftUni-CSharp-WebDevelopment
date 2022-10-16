using System;
using System.Linq;

namespace _11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> predicate = (name, n) => name.Sum(c => c) >= n;
            Func<int, string[], Func<string, int, bool>, string> getFirstMatch = (n, names, match) 
                => names.First(name => match(name, n));
            
            Console.WriteLine(getFirstMatch(int.Parse(Console.ReadLine()), 
                Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), predicate));
        }
    }
}
