using System;

namespace OIdBooks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string favBook = Console.ReadLine();
            string input = "";
            int counter = 0;

            while (input != "No More Books")
            {
                input = Console.ReadLine();
                if (input == favBook)
                {
                    Console.WriteLine($"You checked {counter} books and found it.");
                    break;
                }
                counter++;
            }

            if (input == "No More Books")
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {counter-1} books.");
            }
        }
    }
}
