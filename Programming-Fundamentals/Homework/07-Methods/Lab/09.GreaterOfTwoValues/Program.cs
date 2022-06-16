using System;

namespace _09.GreaterOfTwoValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();

            switch (type)
            {
                case "int":
                    Console.WriteLine(GetMax(int.Parse(input1), int.Parse(input2)));
                    break;
                case "char":
                    Console.WriteLine(GetMax(char.Parse(input1), char.Parse(input2)));
                    break;
                case "string":
                    Console.WriteLine(GetMax(input1, input2));
                    break;
            }
        }

        static int GetMax(int a, int b)
        {
            return a > b ? a : b;
        }

        static char GetMax(char a, char b)
        {
            return a > b ? a : b;
        }

        static string GetMax(string a, string b)
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }
}
