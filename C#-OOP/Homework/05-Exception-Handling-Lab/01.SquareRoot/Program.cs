using System;

namespace _01.SquareRoot
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(Sqrt(int.Parse(Console.ReadLine())));
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }

        private static double Sqrt(int x)
        {
            if (x < 0)
                throw new ArgumentException("Invalid number.");

            return Math.Sqrt(x);
        }
    }
}
