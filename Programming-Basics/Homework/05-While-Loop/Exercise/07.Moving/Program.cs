using System;

namespace Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int space = width * height * length;
            string input = Console.ReadLine();

            while (space > 0 && input != "Done")
            {
                space -= int.Parse(input);
                if (space > 0)
                    input = Console.ReadLine();
            }

            if (input == "Done")
                Console.WriteLine($"{space} Cubic meters left.");
            else if (space <= 0)
                Console.WriteLine($"No more free space! You need {-space} Cubic meters more.");
        }
    }
}
