using System;

namespace Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int pieces = width * height;
            string input = Console.ReadLine();

            while (pieces > 0 && input != "STOP")
            {
                pieces -= int.Parse(input);
                if (pieces > 0)
                    input = Console.ReadLine();
            }

            if (input == "STOP")
                Console.WriteLine($"{pieces} pieces are left.");
            else if (pieces <= 0)
                Console.WriteLine($"No more cake left! You need {-pieces} pieces more.");
        }
    }
}
