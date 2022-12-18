namespace Chainblock
{
    using System;
    using Contracts;

    public class Transaction : ITransaction
    {
        private int id;
        private string from;
        private string to;
        private double amount;

        public Transaction(int id, TransactionStatus status, string from, string to, double amount)
        {
            Id = id;
            Status = status;
            From = from;
            To = to;
            Amount = amount;
        }

        public int Id
        {
            get => id;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Id cannot be 0 or less!");

                id = value;
            }
        }

        public TransactionStatus Status { get; set; }

        public string From
        {
            get => from;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("From cannot be null or white space!");

                from = value;
            }
        }

        public string To
        {
            get => to;
            set
            {

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("From cannot be null or white space!");

                to = value;
            }
        }

        public double Amount
        {
            get => amount;
            set
            {

                if (value <= 0)
                    throw new ArgumentException("Amount cannot be 0 or less!");

                amount = value;
            }
        }
    }
}