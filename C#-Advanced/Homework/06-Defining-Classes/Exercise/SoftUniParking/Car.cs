﻿using System;

namespace SoftUniParking
{
    public class Car
    {
        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }

        public override string ToString()
            => $"Make: {Make}\n" +
               $"Model: {Model}\n" +
               $"HorsePower: {HorsePower}\n" +
               $"RegistrationNumber: {RegistrationNumber}";
    }
}
