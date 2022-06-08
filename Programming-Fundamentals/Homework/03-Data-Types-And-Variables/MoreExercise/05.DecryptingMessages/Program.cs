using System;

namespace _05.DecryptingMessages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            string message = "";
            for (int i = 0; i < n; i++)
            {
                char input = char.Parse(Console.ReadLine());
                message += (char) (input + key);
            }

            Console.WriteLine(message);
        }
    }
}
