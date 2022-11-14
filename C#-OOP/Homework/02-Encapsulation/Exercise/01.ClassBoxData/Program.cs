using System;

namespace _01.ClassBoxData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(new Box(
                    double.Parse(Console.ReadLine()), 
                    double.Parse(Console.ReadLine()), 
                    double.Parse(Console.ReadLine())));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
