using System;

namespace FoodDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chickenMenus = int.Parse(Console.ReadLine());
            int fishMenus = int.Parse(Console.ReadLine());
            int vegetarianMenus = int.Parse(Console.ReadLine());

            double foodPrice = chickenMenus * 10.35 + fishMenus * 12.4 + vegetarianMenus * 8.15;
            double dessertPrice = foodPrice * 0.2;
            double price = foodPrice + dessertPrice + 2.5;
            Console.WriteLine(price);
        }
    }
}
