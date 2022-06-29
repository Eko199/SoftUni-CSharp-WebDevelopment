using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.VehicleCatalogue
{
    internal class Program
    {
        internal class Truck
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Weight { get; set; }

            public Truck(string brand, string model, int weight)
            {
                Brand = brand;
                Model = model;
                Weight = weight;
            }

            public override string ToString() => $"{Brand}: {Model} - {Weight}kg";
        }

        internal class Car
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int HorsePower { get; set; }

            public Car(string brand, string model, int horsePower)
            {
                Brand = brand;
                Model = model;
                HorsePower = horsePower;
            }

            public override string ToString() => $"{Brand}: {Model} - {HorsePower}hp";
        }

        internal class Catalog
        {
            public List<Car> Cars { get; set; }
            public List<Truck> Trucks { get; set; }

            public Catalog()
            {
                Cars = new List<Car>();
                Trucks = new List<Truck>();
            }
        }

        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();
            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] vehicleInfo = input.Split('/');
                
                switch (vehicleInfo[0])
                {
                    case "Car":
                        catalog.Cars.Add(new Car(vehicleInfo[1], vehicleInfo[2], int.Parse(vehicleInfo[3])));
                        break;
                    case "Truck":
                        catalog.Trucks.Add(new Truck(vehicleInfo[1], vehicleInfo[2], int.Parse(vehicleInfo[3])));
                        break;
                }

                input = Console.ReadLine();
            }
            
            if (catalog.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                catalog.Cars.OrderBy(car => car.Brand).ToList().ForEach(car => Console.WriteLine(car.ToString()));
            }

            if (catalog.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                catalog.Trucks.OrderBy(truck => truck.Brand).ToList().ForEach(truck => Console.WriteLine(truck.ToString()));
            }
        }
    }
}
