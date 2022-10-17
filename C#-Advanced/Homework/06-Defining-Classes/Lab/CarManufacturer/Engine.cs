using System;

namespace CarManufacturer
{
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public Engine(int horsePower, double cubicCapacity)
        {
            this.horsePower = horsePower;
            this.cubicCapacity = cubicCapacity;
        }

        public int HorsePower
        {
            get => horsePower;
            set => horsePower = value;
        }

        public double CubicCapacity
        {
            get => cubicCapacity;
            set => cubicCapacity = value;
        }
    }
}
