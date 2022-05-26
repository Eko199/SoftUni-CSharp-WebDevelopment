using System;

namespace AccountBalance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double balance = 0;
            string command = Console.ReadLine();

            while (command != "NoMoreMoney")
            {
                double increase = double.Parse(command);
                if (increase < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {increase:f2}");
                balance += increase;
                command = Console.ReadLine();
            }

            Console.WriteLine($"Total: {balance:f2}");
        }
    }
}
