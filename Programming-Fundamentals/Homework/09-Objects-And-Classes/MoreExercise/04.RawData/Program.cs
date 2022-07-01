using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.RawData
{
    class Engine
    {
        public int Speed { get; set; }
        public int Power { get; set; }

        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }
    }

    class Cargo
    {
        public int Weight { get; set; }
        public string Type { get; set; }

        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }
    }

    class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }

        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType)
        {
            Model = model;
            Engine = new Engine(engineSpeed, enginePower);
            Cargo = new Cargo(cargoWeight, cargoType);
        }
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
                cars.Add(new Car(carInfo[0], int.Parse(carInfo[1]), int.Parse(carInfo[2]), int.Parse(carInfo[3]), carInfo[4]));
            }

            string type = Console.ReadLine();
            List<Car> typeCars = cars.Where(car => car.Cargo.Type == type).ToList();

            switch (type)
            {
                case "fragile":
                    Console.WriteLine(string.Join(Environment.NewLine, cars.Where(car => car.Cargo.Weight < 1000).Select(car => car.Model)));
                    break;
                case "flamable":
                    Console.WriteLine(string.Join(Environment.NewLine, cars.Where(car => car.Engine.Power > 250).Select(car => car.Model)));
                    break;
            }
        }
    }
}
