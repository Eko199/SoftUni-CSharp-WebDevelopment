using System;

namespace _12.RefractorSpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                int current = i;
                int obshto = 0;

                while (i > 0)
                {
                    obshto += i % 10;
                    i /= 10;
                }

                bool isSpecial = (obshto == 5) || (obshto == 7) || (obshto == 11);

                Console.WriteLine("{0} -> {1}", current, isSpecial);

                obshto = 0;

                i = current;
            }
        }
    }
}
