using System;
using System.Collections.Generic;

namespace _03.SpeedRacing
{
    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumption { get; set; }
        public int TraveledDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumption = fuelConsumption;
        }

        public void Move(int distance)
        {
            double neededFuel = distance * FuelConsumption;

            if (FuelAmount >= neededFuel)
            {
                FuelAmount -= neededFuel;
                TraveledDistance += distance;
            }
            else
                Console.WriteLine("Insufficient fuel for the drive");
        }

        public override string ToString() =>  $"{Model} {FuelAmount:f2} {TraveledDistance}";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                cars.Add(new Car(carInfo[0], double.Parse(carInfo[1]), double.Parse(carInfo[2])));
            }

            string[] commands = Console.ReadLine().Split();
            while (commands[0] != "End")
            {
                cars.Find(car => car.Model == commands[1]).Move(int.Parse(commands[2]));
                commands = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}
