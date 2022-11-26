namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity) { }

        protected override double FuelConsumptionIncrement => 1.6;

        public override void Refuel(double liters) => base.Refuel(liters * 0.95);
    }
}
