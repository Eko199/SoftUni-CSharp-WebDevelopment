namespace Chainblock
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    using Contracts;

    public class Chainblock : IChainblock
    {
        private readonly ICollection<ITransaction> transactions;

        public Chainblock()
        {
            transactions = new List<ITransaction>();
        }

        public int Count => transactions.Count;

        public void Add(ITransaction tx)
        {
            if (Contains(tx.Id))
                throw new InvalidOperationException($"Transaction with id {tx.Id} is already added!");

            transactions.Add(tx);
        }

        public bool Contains(ITransaction tx) => Contains(tx.Id);

        public bool Contains(int id) => transactions.Any(t => t.Id == id);

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            try
            {
                GetById(id).Status = newStatus;
            }
            catch (InvalidOperationException ioe)
            {
                throw new ArgumentException(ioe.Message, ioe);
            }
        }

        public void RemoveTransactionById(int id) => transactions.Remove(GetById(id));

        public ITransaction GetById(int id)
        {
            ITransaction transaction = transactions.SingleOrDefault(t => t.Id == id);

            if (transaction == null)
                throw new InvalidOperationException($"There is no transaction with id {id}");

            return transaction;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            IEnumerable<ITransaction> result = transactions
                    .Where(t => t.Status == status)
                    .OrderByDescending(t => t.Amount);

            if (!result.Any())
                throw new InvalidOperationException($"There are no transactions with status {status}!");

            return result;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status) 
            => GetByTransactionStatus(status).Select(t => t.From);

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
            => GetByTransactionStatus(status).Select(t => t.To);

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
            => transactions.OrderByDescending(t => t.Amount).ThenBy(t => t.Id);

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            IEnumerable<ITransaction> result = transactions
                .Where(t => t.From == sender)
                .OrderByDescending(t => t.Amount);

            if (!result.Any())
                throw new InvalidOperationException($"There are no transactions from {sender}!");

            return result;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            IEnumerable<ITransaction> result = transactions
                .Where(t => t.To == receiver)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);

            if (!result.Any())
                throw new InvalidOperationException($"There are no transactions to {receiver}!");

            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
            => transactions.Where(t => t.Status == status && t.Amount <= amount).OrderByDescending(t => t.Amount);

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            IEnumerable<ITransaction> result = transactions
                .Where(t => t.From == sender && t.Amount > amount)
                .OrderByDescending(t => t.Amount);

            if (!result.Any())
                throw new InvalidOperationException($"There are no transactions from {sender} with amount greater than {amount}!");

            return result;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            IEnumerable<ITransaction> result = transactions
                .Where(t => t.To == receiver && t.Amount >= lo && t.Amount < hi)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);

            if (!result.Any())
                throw new InvalidOperationException($"There are no transactions to {receiver} that are in [{lo};{hi})!");

            return result;
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
            => transactions.Where(t => t.Amount >= lo && t.Amount <= hi);

        public IEnumerator<ITransaction> GetEnumerator() => transactions.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}