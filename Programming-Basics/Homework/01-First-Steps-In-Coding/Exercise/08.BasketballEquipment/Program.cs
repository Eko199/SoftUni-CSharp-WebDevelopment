using System;

namespace BasketballEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yearPrice = int.Parse(Console.ReadLine());

            double shoesPrice = yearPrice * 0.6;
            double clothesPrice = shoesPrice * 0.8;
            double ballPrice = clothesPrice / 4;
            double accessoriesPrice = ballPrice / 5;

            double price = yearPrice + shoesPrice + clothesPrice + ballPrice + accessoriesPrice;
            Console.WriteLine(price);
        }
    }
}
