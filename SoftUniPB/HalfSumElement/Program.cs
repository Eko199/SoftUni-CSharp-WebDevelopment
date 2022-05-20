using System;

namespace HalfSumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0, max = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                int a = int.Parse(Console.ReadLine());
                sum += a;
                if (a > max)
                    max = a;
            }

            if (max == sum - max)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {max}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(sum - 2 * max)}");
            }    
        }
    }
}
