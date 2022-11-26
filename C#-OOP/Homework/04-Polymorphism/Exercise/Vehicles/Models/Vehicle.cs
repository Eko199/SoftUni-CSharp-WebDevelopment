namespace Vehicles.Models
{
    using System;

    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;

            try
            {
                FuelQuantity = fuelQuantity;
            }
            catch (InvalidOperationException)
            {
                FuelQuantity = 0;
            }

            this.fuelConsumption = fuelConsumption;
        }

        protected abstract double FuelConsumptionIncrement { get; }
        private double TankCapacity { get; }

        private double FuelQuantity
        {
            get => fuelQuantity;
            set
            {
                if (value > TankCapacity)
                    throw new InvalidOperationException(
                        $"Cannot fit {(value - FuelQuantity is double addedFuel && this is Truck ? addedFuel * 100 / 95 : addedFuel)} fuel in the tank");

                fuelQuantity = value;
            }
        }

        private double RealFuelConsumption => fuelConsumption + FuelConsumptionIncrement;

        public string Drive(double distance)
        {
            double neededFuel = distance * RealFuelConsumption;

            if (FuelQuantity < neededFuel) 
                return GetType().Name + " needs refueling";

            FuelQuantity -= neededFuel;
            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
                throw new ArgumentException("Fuel must be a positive number");

            FuelQuantity += liters;
        }

        public override string ToString() => $"{GetType().Name}: {FuelQuantity:F2}";
    }
}
