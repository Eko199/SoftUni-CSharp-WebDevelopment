using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            List<Tire[]> tires = new List<Tire[]>();

            string command = Console.ReadLine();
            while (command != "No more tires")
            {
                string[] tiresInfo = command.Split();

                var currentTires = new Tire[4];
                for (int i = 0; i < 8; i += 2)
                    currentTires[i / 2] = new Tire(int.Parse(tiresInfo[i]), double.Parse(tiresInfo[i + 1]));
                tires.Add(currentTires);

                command = Console.ReadLine();
            }

            List<Engine> engines = new List<Engine>();

            command = Console.ReadLine();
            while (command != "Engines done")
            {
                string[] engineInfo = command.Split();
                engines.Add(new Engine(int.Parse(engineInfo[0]), double.Parse(engineInfo[1])));

                command = Console.ReadLine();
            }

            List<Car> cars = new List<Car>();

            command = Console.ReadLine();
            while (command != "Show special")
            {
                string[] carInfo = command.Split();
                cars.Add(new Car(carInfo[0], carInfo[1], int.Parse(carInfo[2]), 
                    double.Parse(carInfo[3]), double.Parse(carInfo[4]), 
                    engines[int.Parse(carInfo[5])], tires[int.Parse(carInfo[5])]));

                command = Console.ReadLine();
            }

            foreach (Car car in cars
                         .Where(car => car.Year >= 2017 && 
                                       car.Engine.HorsePower > 330 && 
                                       car.Tires.Select(tire => tire.Pressure).Sum() is >= 9 and <= 10))
            {
                car.Drive(0.2);
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}