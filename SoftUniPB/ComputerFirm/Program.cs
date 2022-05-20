using System;

namespace ComputerFirm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double sales = 0;
            double ratingSum = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                int rating = number % 10;
                int possibleSales = number / 10;

                ratingSum += rating;
                switch (rating)
                {
                    case 2:
                        break;
                    case 3:
                        sales += possibleSales * 0.5;
                        break;
                    case 4:
                        sales += possibleSales * 0.7;
                        break;
                    case 5:
                        sales += possibleSales * 0.85;
                        break;
                    case 6:
                        sales += possibleSales;
                        break;
                }
            }

            Console.WriteLine($"{sales:f2}");
            Console.WriteLine($"{ratingSum / n:f2}");
        }
    }
}
