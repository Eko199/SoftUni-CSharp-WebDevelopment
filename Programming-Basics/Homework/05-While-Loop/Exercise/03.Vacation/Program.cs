using System;

namespace Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int days = 0, daysSpending = 0;

            while (neededMoney > budget)
            {
                string action = Console.ReadLine();
                double amount = double.Parse(Console.ReadLine());
                days++;

                if (action == "spend")
                {
                    daysSpending++;
                    if (daysSpending >= 5)
                        break;
                    budget -= amount;
                    if (budget <= 0)
                        budget = 0;
                }
                else if (action == "save")
                {
                    budget += amount;
                    daysSpending = 0;
                }
            }

            if (daysSpending >= 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(days);
            }
            else
            {
                Console.WriteLine($"You saved the money for {days} days.");
            }
        }
    }
}
