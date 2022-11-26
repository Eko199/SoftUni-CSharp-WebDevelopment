namespace Vehicles.Core
{
    using System;

    using Factories;
    using Interfaces;
    using IO.Interfaces;
    using Models;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly VehicleFactory vehicleFactory;

        private Vehicle car;
        private Vehicle truck;
        private Vehicle bus;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            vehicleFactory = new VehicleFactory();
        }

        public void Run()
        {
            try
            {
                car = BuildVehicleUsingFactory();
                truck = BuildVehicleUsingFactory();
                bus = BuildVehicleUsingFactory();

                int n = int.Parse(reader.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    try
                    {
                        ProcessCommand(reader.ReadLine());
                    }
                    catch (ArgumentException ae)
                    {
                        writer.WriteLine(ae.Message);
                    }
                    catch (InvalidOperationException ioe)
                    {
                        writer.WriteLine(ioe.Message);
                    }
                }

                PrintVehicles();
            }
            catch (ArgumentException ae)
            {
                writer.WriteLine(ae.Message);
            }
        }

        private Vehicle BuildVehicleUsingFactory()
        {
            string[] vehicleInfo = reader.ReadLine().Split();
            return vehicleFactory.CreateVehicle(vehicleInfo[0], double.Parse(vehicleInfo[1]),
                double.Parse(vehicleInfo[2]), vehicleInfo.Length > 3 ? double.Parse(vehicleInfo[3]) : double.MaxValue);
        }

        private void ProcessCommand(string command)
        {
            string[] cmdArgs = command.Split();

            string commandType = cmdArgs[0];
            string vehicleType = cmdArgs[1];
            double value = double.Parse(cmdArgs[2]);

            Vehicle vehicleToUse = vehicleType switch
            {
                "Car" => car,
                "Truck" => truck,
                "Bus" => bus,
                _ => throw new ArgumentException("Invalid vehicle!")
            };

            switch (commandType)
            {
                case "Drive":
                    writer.WriteLine(vehicleToUse.Drive(value));
                    break;
                case "Refuel":
                    vehicleToUse.Refuel(value);
                    break;
                case "DriveEmpty":
                    if (vehicleToUse is not Bus bus) 
                        throw new ArgumentException("Only bus can drive empty!");

                    writer.WriteLine(bus.Drive(value, true));
                    break;
                default:
                    throw new ArgumentException("Invalid command!");
            }
        }

        private void PrintVehicles()
        {
            writer.WriteLine(car);
            writer.WriteLine(truck);
            writer.WriteLine(bus);
        }
    }
}
