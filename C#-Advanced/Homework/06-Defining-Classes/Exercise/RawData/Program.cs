using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
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
                cars.Add(new Car(
                    carInfo[0],
                    new Engine(int.Parse(carInfo[1]), int.Parse(carInfo[2])),
                    new Cargo(int.Parse(carInfo[3]), carInfo[4]),
                    new Tire[]
                    {
                        new Tire(double.Parse(carInfo[5]), int.Parse(carInfo[6])),
                        new Tire(double.Parse(carInfo[7]), int.Parse(carInfo[8])),
                        new Tire(double.Parse(carInfo[9]), int.Parse(carInfo[10])),
                        new Tire(double.Parse(carInfo[11]), int.Parse(carInfo[12]))
                    }));
            }

            string cargoType = Console.ReadLine();
            Console.WriteLine(string.Join(Environment.NewLine, cars
                .Where(car => car.Cargo.Type == cargoType && cargoType == "fragile" 
                    ? car.Tires.Any(tire => tire.Pressure < 1) 
                    : car.Engine.Power > 250)
                .Select(car => car.Model)));
        }
    }
}
