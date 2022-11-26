namespace Vehicles.Factories
{
    using System;

    using Models;

    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
            => type switch
            {
                "Car" => new Car(fuelQuantity, fuelConsumption, tankCapacity),
                "Truck" => new Truck(fuelQuantity, fuelConsumption, tankCapacity),
                "Bus" => new Bus(fuelQuantity, fuelConsumption, tankCapacity),
                _ => throw new ArgumentException("Invalid vehicle type!")
            };
    }
}
