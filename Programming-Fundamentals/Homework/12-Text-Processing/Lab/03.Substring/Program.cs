using System;

namespace _03.Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string substring = Console.ReadLine();
            string str = Console.ReadLine();

            while (str.Contains(substring))
                str = str.Replace(substring, string.Empty);

            Console.WriteLine(str);
        }
    }
}
