using System;

namespace _01.DataTypeFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                if (int.TryParse(input, out int intResult))
                    Console.WriteLine(input + " is integer type");
                else if (float.TryParse(input, out float floatResult))
                    Console.WriteLine(input + " is floating point type");
                else if (char.TryParse(input, out char charResult))
                    Console.WriteLine(input + " is character type");
                else if (bool.TryParse(input, out bool boolResult))
                    Console.WriteLine(input + " is boolean type");
                else
                    Console.WriteLine(input + " is string type");

                input = Console.ReadLine();
            }
        }
    }
}
