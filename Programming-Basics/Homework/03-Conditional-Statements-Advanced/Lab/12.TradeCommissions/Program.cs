using System;

namespace TradeCommissions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());

            double commission = -1;
            if (0 <= sales && sales <= 500)
            {
                switch (city)
                {
                    case "Sofia":
                        commission = sales * 0.05;
                        break;
                    case "Varna":
                        commission = sales * 0.045;
                        break;
                    case "Plovdiv":
                        commission = sales * 0.055;
                        break;
                }
            }
            else if (500 < sales && sales <= 1000)
            {
                switch (city)
                {
                    case "Sofia":
                        commission = sales * 0.07;
                        break;
                    case "Varna":
                        commission = sales * 0.075;
                        break;
                    case "Plovdiv":
                        commission = sales * 0.08;
                        break;
                }
            }
            else if (1000 < sales && sales <= 10000)
            {
                switch (city)
                {
                    case "Sofia":
                        commission = sales * 0.08;
                        break;
                    case "Varna":
                        commission = sales * 0.1;
                        break;
                    case "Plovdiv":
                        commission = sales * 0.12;
                        break;
                }
            }
            else if (sales > 10000)
            {
                switch (city)
                {
                    case "Sofia":
                        commission = sales * 0.12;
                        break;
                    case "Varna":
                        commission = sales * 0.13;
                        break;
                    case "Plovdiv":
                        commission = sales * 0.145;
                        break;
                }
            }

            if (commission != -1)
                Console.WriteLine($"{commission:f2}");
            else
                Console.WriteLine("error");
        }
    }
}