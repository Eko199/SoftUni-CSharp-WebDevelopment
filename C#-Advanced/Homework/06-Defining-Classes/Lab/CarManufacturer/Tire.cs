﻿using System;

namespace CarManufacturer
{
    public class Tire
    {
        private int year;
        private double pressure;

        public Tire(int year, double pressure)
        {
            this.year = year;
            this.pressure = pressure;
        }

        public int Year
        {
            get => year;
            set => year = value;
        }

        public double Pressure
        {
            get => pressure;
            set => pressure = value;
        }
    }
}
