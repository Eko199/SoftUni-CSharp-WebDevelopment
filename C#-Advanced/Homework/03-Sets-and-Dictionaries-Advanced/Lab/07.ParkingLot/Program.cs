using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var parkingSet = new HashSet<string>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] tokens = input.Split(", ");

                switch (tokens[0])
                {
                    case "IN":
                        parkingSet.Add(tokens[1]);
                        break;
                    case "OUT":
                        parkingSet.Remove(tokens[1]);
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(parkingSet.Any() ? string.Join(Environment.NewLine, parkingSet) : "Parking Lot is Empty");
        }
    }
}
