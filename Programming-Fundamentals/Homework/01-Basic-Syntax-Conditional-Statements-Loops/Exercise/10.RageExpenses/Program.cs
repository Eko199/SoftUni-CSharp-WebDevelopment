using System;

namespace _10.RageExpenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int losses = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int trashedHeadsets = 0;
            int trashedMouses = 0;
            int trashedKeyboards = 0;
            int trashedDisplays = 0;

            for (int i = 1; i <= losses; i++)
            {
                if (i % 2 == 0)
                    trashedHeadsets++;
                if (i % 3 == 0)
                    trashedMouses++;
                if (i % 6 == 0)
                    trashedKeyboards++;
                if (i % 12 == 0)
                    trashedDisplays++;
            }

            double expenses = trashedHeadsets * headsetPrice
                              + trashedMouses * mousePrice
                              + trashedKeyboards * keyboardPrice
                              + trashedDisplays * displayPrice;
            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}
