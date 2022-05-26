using System;

namespace TrekkingMania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());
            int mussala = 0, monblan = 0, kilimandzharo = 0, k2 = 0, everest = 0;
            for (int i = 0; i < groups; i++)
            {
                int members = int.Parse(Console.ReadLine());
                if (members <= 5)
                    mussala += members;
                else if (members <= 12)
                    monblan += members;
                else if (members <= 25)
                    kilimandzharo += members;
                else if (members <= 40)
                    k2 += members;
                else
                    everest += members;
            }
            int people = mussala + monblan + kilimandzharo + k2 + everest;
            Console.WriteLine($"{mussala * 100.0 / people:f2}%");
            Console.WriteLine($"{monblan * 100.0 / people:f2}%");
            Console.WriteLine($"{kilimandzharo * 100.0 / people:f2}%");
            Console.WriteLine($"{k2 * 100.0 / people:f2}%");
            Console.WriteLine($"{everest * 100.0 / people:f2}%");
        }
    }
}
