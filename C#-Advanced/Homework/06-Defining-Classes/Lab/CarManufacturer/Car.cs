using System;

namespace CarManufacturer
{
    class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public Car()
        {
            make = "VW";
            model = "Golf";
            year = 2025;
            fuelQuantity = 200;
            fuelConsumption = 10;
        }

        public Car(string make, string model, int year) : this()
        {
            this.make = make;
            this.model = model;
            this.year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires) : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.engine = engine;
            this.tires = tires;
        }

        public string Make
        {
            get => make;
            set => make = value;
        }

        public string Model
        {
            get => model;
            set => model = value;
        }

        public int Year
        {
            get => year;
            set => year = value;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            set => fuelQuantity = value;
        }

        public double FuelConsumption
        {
            get => fuelConsumption;
            set => fuelConsumption = value;
        }

        public Engine Engine
        {
            get => engine;
            set => engine = value;
        }

        public Tire[] Tires
        {
            get => tires;
            set => tires = value;
        }

        public void Drive(double distance)
        {
            double leftFuel = fuelQuantity - fuelConsumption * distance;

            if (leftFuel < 0)
                Console.WriteLine("Not enough fuel to perform this trip!");
            else
                fuelQuantity = leftFuel;
        }

        public string WhoAmI() =>
            $"Make: {this.Make}\n" +
            $"Model: {this.Model}\n" +
            $"Year: {this.Year}\n" +
            $"HorsePowers: {this.Engine.HorsePower}\n" +
            $"FuelQuantity: {this.FuelQuantity}";
    }
}