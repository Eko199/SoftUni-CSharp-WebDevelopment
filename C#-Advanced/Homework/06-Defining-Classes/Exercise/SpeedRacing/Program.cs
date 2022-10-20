using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                cars.Add(new Car(carInfo[0], double.Parse(carInfo[1]), 
                    double.Parse(carInfo[2])));
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] tokens = command.Split();

                cars.Single(car => car.Model == tokens[1]).Drive(double.Parse(tokens[2]));

                command = Console.ReadLine();
            }

            cars.ForEach(car => Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}"));
        }
    }
}
