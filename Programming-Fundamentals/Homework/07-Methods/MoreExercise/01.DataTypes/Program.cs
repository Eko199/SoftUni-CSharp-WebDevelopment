using System;

namespace _01.DataTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();

            switch (input1)
            {
                case "int":
                    IntCase(input2);
                    break;
                case "real":
                    RealCase(input2);
                    break;
                case "string":
                    StringCase(input2);
                    break;
            }
        }

        private static void IntCase(string text)
        {
            int number = int.Parse(text) * 2;
            Console.WriteLine(number);
        }

        private static void RealCase(string text)
        {
            double number = double.Parse(text) * 1.5;
            Console.WriteLine($"{number:f2}");
        }

        private static void StringCase(string text)
        {
            Console.WriteLine("$" + text + "$");
        }
    }
}
