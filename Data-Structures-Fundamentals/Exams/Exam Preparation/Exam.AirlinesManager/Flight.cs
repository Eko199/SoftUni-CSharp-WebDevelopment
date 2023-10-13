namespace Exam.DeliveriesManager
{
    using System;
    using System.Collections.Generic;

    public class Flight
    {
        public Flight(string id, string number, string origin, string destination, bool isCompleted)
        {
            Id = id;
            Number = number;
            Origin = origin;
            Destination = destination;
            IsCompleted = isCompleted;
        }

        public string Id { get; set; }

        public string Number { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public bool IsCompleted { get; set; }
    }

    public class FlightCompletionNumberComparer : IComparer<Flight>
    {
        public int Compare(Flight x, Flight y)
        {
            if (x is null && y is null)
                return 0;

            if (x is null)
                return -1;

            if (y is null)
                return 1;

            if (x.Id == y.Id)
                return 0;

            return x.IsCompleted.CompareTo(y.IsCompleted) != 0
                ? x.IsCompleted.CompareTo(y.IsCompleted)
                : string.Compare(x.Number, y.Number, StringComparison.Ordinal);
        }
    }
}
