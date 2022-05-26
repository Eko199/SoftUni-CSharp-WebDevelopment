using System;

namespace FruitMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double strawberryPrice = double.Parse(Console.ReadLine());
            double bananas = double.Parse(Console.ReadLine());
            double oranges = double.Parse(Console.ReadLine());
            double raspberries = double.Parse(Console.ReadLine());
            double strawberries = double.Parse(Console.ReadLine());

            double raspberryPrice = strawberryPrice / 2;
            double orangePrice = raspberryPrice * 0.6;
            double bananaPrice = raspberryPrice * 0.2;

            double price = strawberryPrice * strawberries + bananaPrice * bananas + orangePrice * oranges + raspberryPrice * raspberries;
            Console.WriteLine($"{price:f2}");
        }
    }
}
