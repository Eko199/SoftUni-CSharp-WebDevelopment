using System;
using System.Collections.Generic;

namespace Exam.DeliveriesManager
{
    using System.Linq;
    using _02.BinarySearchTree;

    public class AirlinesManager : IAirlinesManager
    {
        private readonly BinarySearchTree<Flight> flights = new BinarySearchTree<Flight>(new FlightCompletionNumberComparer());
        private readonly Dictionary<string, Airline> airlines = new Dictionary<string, Airline>();
        private readonly Dictionary<string, HashSet<string>> airlinesFlights = new Dictionary<string, HashSet<string>>();

        public void AddAirline(Airline airline)
        {
            airlines.Add(airline.Id, airline);
            airlinesFlights.Add(airline.Id, new HashSet<string>());
        }

        public void AddFlight(Airline airline, Flight flight)
        {
            if (!Contains(airline))
                throw new ArgumentException();

            flights.Insert(flight);
            airlinesFlights[airline.Id].Add(flight.Id);
        }

        public bool Contains(Airline airline) => airlines.ContainsKey(airline.Id);

        public bool Contains(Flight flight) => flights.Contains(flight);

        public void DeleteAirline(Airline airline)
        {
            if (!Contains(airline))
                throw new ArgumentException();

            foreach (string flightId in airlinesFlights[airline.Id])
            {
                flights.Delete(new Flight(flightId, "", "", "", false));
            }

            airlinesFlights.Remove(airline.Id);
            airlines.Remove(airline.Id);
        }

        public IEnumerable<Airline> GetAirlinesOrderedByRatingThenByCountOfFlightsThenByName()
            => airlines.Values
                .OrderByDescending(a => a.Rating)
                .ThenByDescending(a => airlinesFlights[a.Id].Count)
                .ThenBy(a => a.Name);

        public IEnumerable<Airline> GetAirlinesWithFlightsFromOriginToDestination(string origin, string destination)
        {
            var flightsFromTo = GetAllFlights()
                .Where(f => !f.IsCompleted && f.Origin == origin && f.Destination == destination)
                .Select(f => f.Id);

            return airlines.Keys.Where(k => airlinesFlights[k].Intersect(flightsFromTo).Any()).Select(k => airlines[k]);
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            var result = new List<Flight>();
            flights.EachInOrder(result.Add);
            return result;
        }

        public IEnumerable<Flight> GetCompletedFlights() => GetAllFlights().Where(f => f.IsCompleted);

        public IEnumerable<Flight> GetFlightsOrderedByCompletionThenByNumber() => GetAllFlights();

        public Flight PerformFlight(Airline airline, Flight flight)
        {
            if (!Contains(airline) || !Contains(flight))
                throw new ArgumentException();

            flight.IsCompleted = true;
            return flight;
        }
    }
}
