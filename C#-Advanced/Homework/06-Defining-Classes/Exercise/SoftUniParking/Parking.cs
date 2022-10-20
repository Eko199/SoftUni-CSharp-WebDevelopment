using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;
        private List<Car> cars;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new List<Car>(capacity);
        }

        public int Count => cars.Count;

        public string AddCar(Car car)
        {
            if (cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
                return "Car with that registration number, already exists!";

            if (cars.Count >= capacity)
                return "Parking is full!";

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (cars.All(car => car.RegistrationNumber != registrationNumber))
                return "Car with that registration number, doesn't exist!";
            
            cars.RemoveAll(car => car.RegistrationNumber == registrationNumber);
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
            => cars.Single(car => car.RegistrationNumber == registrationNumber);

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            registrationNumbers.ForEach(number => Console.WriteLine(RemoveCar(number)));
        }
    }
}
