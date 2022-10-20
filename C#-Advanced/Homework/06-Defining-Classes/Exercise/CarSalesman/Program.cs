using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var engines = new List<Engine>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                engines.Add(engineInfo.Length switch
                {
                    2 => new Engine(engineInfo[0], int.Parse(engineInfo[1])),
                    3 => int.TryParse(engineInfo[2], out int displacement) 
                        ? new Engine(engineInfo[0], int.Parse(engineInfo[1]), displacement) 
                        : new Engine(engineInfo[0], int.Parse(engineInfo[1]), engineInfo[2]),
                    4 => new Engine(engineInfo[0], int.Parse(engineInfo[1]), int.Parse(engineInfo[2]), engineInfo[3])
                });
            }

            var cars = new List<Car>();
            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Engine engine = engines.Single(engine => engine.Model == carInfo[1]);

                cars.Add(carInfo.Length switch
                {
                    2 => new Car(carInfo[0], engine),
                    3 => int.TryParse(carInfo[2], out int weight) 
                        ? new Car(carInfo[0], engine, weight) 
                        : new Car(carInfo[0], engine, carInfo[2]),
                    4 => new Car(carInfo[0], engine, int.Parse(carInfo[2]), carInfo[3])
                });
            }

            cars.ForEach(Console.WriteLine);
        }
    }
}
