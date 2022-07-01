using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.VehicleCatalogue
{
    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public Vehicle(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public override string ToString() => $"Type: {char.ToUpper(Type[0]) + Type[1..]}\n" +
                                             $"Model: {Model}\n" +
                                             $"Color: {Color}\n" +
                                             $"Horsepower: {HorsePower}";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            string[] vehicleInfo = Console.ReadLine().Split();
            while (vehicleInfo[0] != "End")
            {
                vehicles.Add(new Vehicle(vehicleInfo[0], vehicleInfo[1], vehicleInfo[2], int.Parse(vehicleInfo[3])));
                vehicleInfo = Console.ReadLine().Split();
            }

            string input = Console.ReadLine();
            while (input != "Close the Catalogue")
            {
                if (vehicles.Exists(vehicle => vehicle.Model == input))
                    Console.WriteLine(vehicles.Find(vehicle => vehicle.Model == input));

                input = Console.ReadLine();
            }

            List<Vehicle> carList = vehicles.Where(vehicle => vehicle.Type == "car").ToList();
            double averageHpCars = carList.Any() ? 1.0 * carList.Select(vehicle => vehicle.HorsePower).Sum() / carList.Count : 0;
            Console.WriteLine($"Cars have average horsepower of: {averageHpCars:f2}.");

            List<Vehicle> truckList = vehicles.Where(vehicle => vehicle.Type == "truck").ToList();
            double averageHpTrucks = truckList.Any() ? 1.0 * truckList.Select(vehicle => vehicle.HorsePower).Sum() / truckList.Count : 0;
            Console.WriteLine($"Trucks have average horsepower of: {averageHpTrucks:f2}.");
        }
    }
}
