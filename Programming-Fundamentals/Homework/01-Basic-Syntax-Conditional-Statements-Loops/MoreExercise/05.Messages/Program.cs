using System;

namespace _05.Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = "";
            int length = int.Parse(Console.ReadLine());
            string input;

            for (int i = 0; i < length; i++)
            {
                input = Console.ReadLine();
                int numberIndex = int.Parse(input) % 10 - 2;

                if (numberIndex == -2)
                {
                    message += " ";
                    continue;
                }

                char letter = (char) ('a' + numberIndex * 3 + input.Length - 1 + Convert.ToInt32(numberIndex >= 6));
                message += letter;
            }

            Console.WriteLine(message);
        }
    }
}
