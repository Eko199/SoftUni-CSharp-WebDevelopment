using System;

namespace CleverLily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washPrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());
            double budget = 0;

            int evenBirthdays = age / 2;
            budget += 5 * (evenBirthdays + 1) * evenBirthdays;
            budget -= evenBirthdays;
            int oddBirthdays = age - evenBirthdays;
            budget += toyPrice * oddBirthdays;

            if (budget >= washPrice)
            {
                Console.WriteLine($"Yes! {budget - washPrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {washPrice - budget:f2}");
            }
        }
    }
}
