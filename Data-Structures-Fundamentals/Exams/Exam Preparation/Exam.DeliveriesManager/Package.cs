namespace Exam.DeliveriesManager
{
    using System;
    using System.Collections.Generic;

    public class Package
    {
        public Package(string id, string receiver, string address, string phone, double weight)
        {
            Id = id;
            Receiver = receiver;
            Address = address;
            Phone = phone;
            Weight = weight;
        }

        public string Id { get; set; }

        public string Receiver { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public double Weight { get; set; }
    }

    public class PackageWeightReceiverComparer : IComparer<Package>
    {
        public int Compare(Package x, Package y)
        {
            if (x is null && y is null)
                return 0;

            if (x is null)
                return -1;

            if (y is null)
                return 1;

            return x.Weight.CompareTo(y.Weight) != 0 
                ? y.Weight.CompareTo(x.Weight) 
                : string.Compare(x.Receiver, y.Receiver, StringComparison.Ordinal);
        }
    }
}
