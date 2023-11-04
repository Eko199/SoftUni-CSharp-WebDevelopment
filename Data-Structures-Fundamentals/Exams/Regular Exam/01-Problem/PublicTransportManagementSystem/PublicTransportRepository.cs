using System;
using System.Collections.Generic;

namespace PublicTransportManagementSystem
{
    using System.Linq;

    public class PublicTransportRepository : IPublicTransportRepository
    {
        private readonly Dictionary<string, Passenger> passengers = new Dictionary<string, Passenger>();
        private readonly Dictionary<string, Bus> buses = new Dictionary<string, Bus>();
        private readonly Dictionary<string, List<string>> busPassengers = new Dictionary<string, List<string>>();

        public void RegisterPassenger(Passenger passenger) => passengers[passenger.Id] = passenger;

        public void AddBus(Bus bus)
        {
            buses[bus.Id] = bus;
            busPassengers[bus.Id] = new List<string>();
        }

        public bool Contains(Passenger passenger) => passengers.ContainsKey(passenger.Id);

        public bool Contains(Bus bus) => buses.ContainsKey(bus.Id);

        public IEnumerable<Bus> GetBuses() => buses.Values;

        public void BoardBus(Passenger passenger, Bus bus)
        {
            if (!Contains(passenger) || !Contains(bus))
                throw new ArgumentException();

            busPassengers[bus.Id].Add(passenger.Id);
        }

        public void LeaveBus(Passenger passenger, Bus bus)
        {
            if (!Contains(passenger) || !Contains(bus) || !busPassengers[bus.Id].Contains(passenger.Id))
                throw new ArgumentException();

            busPassengers[bus.Id].Remove(passenger.Id);
        }

        public IEnumerable<Passenger> GetPassengersOnBus(Bus bus)
            => busPassengers[bus.Id].Select(id => passengers[id]);

        public IEnumerable<Bus> GetBusesOrderedByOccupancy()
            => buses.Values.OrderBy(b => busPassengers[b.Id].Count);

        public IEnumerable<Bus> GetBusesWithCapacity(int capacity)
            => buses.Values.Where(b => b.Capacity >= capacity);
    }
}