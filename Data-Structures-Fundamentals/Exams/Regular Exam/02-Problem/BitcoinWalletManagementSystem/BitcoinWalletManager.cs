using System;
using System.Collections.Generic;

namespace BitcoinWalletManagementSystem
{
    using System.Linq;

    public class BitcoinWalletManager : IBitcoinWalletManager
    {
        private readonly Dictionary<string, User> users = new Dictionary<string, User>();
        private readonly Dictionary<string, Wallet> wallets = new Dictionary<string, Wallet>();

        public void CreateUser(User user)
        {
            users[user.Id] = user;
        }

        public void CreateWallet(Wallet wallet)
        {
            wallets[wallet.Id] = wallet;
            wallet.User = users[wallet.UserId];
            wallet.User.Wallets.Add(wallet);
        }

        public bool ContainsUser(User user) => users.ContainsKey(user.Id);

        public bool ContainsWallet(Wallet wallet) => wallets.ContainsKey(wallet.Id);

        public IEnumerable<Wallet> GetWalletsByUser(string userId) => wallets.Values.Where(w => w.UserId == userId);

        public void PerformTransaction(Transaction transaction)
        {
            if (!wallets.ContainsKey(transaction.SenderWalletId) || !wallets.ContainsKey(transaction.ReceiverWalletId)
                || wallets[transaction.SenderWalletId].Balance < transaction.Amount)
            {
                throw new ArgumentException();
            }

            Wallet senderWallet = wallets[transaction.SenderWalletId];
            Wallet receiverWallet = wallets[transaction.ReceiverWalletId];

            senderWallet.Balance -= transaction.Amount;
            receiverWallet.Balance += transaction.Amount;

            senderWallet.User.Transactions.Add(transaction);
            receiverWallet.User.Transactions.Add(transaction);
        }

        public IEnumerable<Transaction> GetTransactionsByUser(string userId)
            => users[userId].Transactions;

        public IEnumerable<Wallet> GetWalletsSortedByBalanceDescending()
            => wallets.Values.OrderByDescending(w => w.Balance);

        public IEnumerable<User> GetUsersSortedByBalanceDescending()
            => users.Values.OrderByDescending(u => u.Wallets.Sum(x => x.Balance));

        public IEnumerable<User> GetUsersByTransactionCount()
            => users.Values.OrderByDescending(u => u.Transactions.Count);
    }
}