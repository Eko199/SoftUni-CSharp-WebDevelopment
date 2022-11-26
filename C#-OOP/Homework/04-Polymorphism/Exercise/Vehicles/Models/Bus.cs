namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private bool isEmpty;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity) { }

        protected override double FuelConsumptionIncrement => isEmpty ? 0 : 1.4;

        public string Drive(double distance, bool isEmpty = false)
        {
            this.isEmpty = isEmpty;
            return base.Drive(distance);
        }
    }
}
