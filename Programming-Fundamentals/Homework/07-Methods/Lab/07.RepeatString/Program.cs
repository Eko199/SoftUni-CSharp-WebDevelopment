using System;
using System.Text;

namespace _07.RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RepeatString(Console.ReadLine(), int.Parse(Console.ReadLine())));
        }

        static string RepeatString(string str, int n)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                sb.Append(str);
            }

            return sb.ToString();
        }
    }
}
