namespace Chainblock.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    using NUnit.Framework;

    [TestFixture]
    public class ChainblockTests
    {
        private ITransaction transaction;
        private ICollection<ITransaction> transactions;
        private IChainblock chainblock, filledChainblock;

        [SetUp]
        public void Setup()
        {
            transaction = new Transaction(1, TransactionStatus.Successful, "asdf", "ghjkl", 10.5);

            transactions = new List<ITransaction>
            {
                transaction,
                new Transaction(32, TransactionStatus.Successful, "asdf", "d", 11.5),
                new Transaction(23, TransactionStatus.Aborted, "a", "b", 0.1),
                new Transaction(14, TransactionStatus.Unauthorized, "b", "a", 1),
                new Transaction(25, TransactionStatus.Failed, "asdf", "ghjkl", 4),
                new Transaction(36, TransactionStatus.Failed, "a", "d", 3),
                new Transaction(47, TransactionStatus.Aborted, "b", "b", 420),
                new Transaction(58, TransactionStatus.Unauthorized, "d", "ghjkl", 69),
                new Transaction(69, TransactionStatus.Successful, "asdf", "a", 11.5),
                new Transaction(90, TransactionStatus.Aborted, "a", "c", 0.1),
                new Transaction(81, TransactionStatus.Unauthorized, "b", "ghjkl", 1),
                new Transaction(72, TransactionStatus.Failed, "asdf", "b", 4),
                new Transaction(63, TransactionStatus.Successful, "a", "a", 3),
                new Transaction(54, TransactionStatus.Successful, "b", "b", 420),
                new Transaction(45, TransactionStatus.Unauthorized, "d", "d", 69),
            };

            chainblock = new Chainblock();
            filledChainblock = new Chainblock();

            foreach (ITransaction t in transactions)
            {
                filledChainblock.Add(t);
            }
        }

        [Test]
        public void Test_ConstructorShouldInitialiseEmptyChainblock()
        {
            Assert.AreEqual(0, chainblock.Count);
        }

        [Test]
        public void Test_AddShouldIncreaseCount()
        {
            chainblock.Add(transaction);
            Assert.AreEqual(1, chainblock.Count);
        }

        [Test]
        public void Test_AddShouldAddTransaction()
        {
            chainblock.Add(transaction);
            Assert.IsTrue(chainblock.Contains(transaction));
        }

        [Test]
        public void Test_AddWithSameIdShouldThrow()
        {
            chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() =>
                chainblock.Add(new Transaction(transaction.Id, TransactionStatus.Successful, "a", "b", 2)));
        }

        [Test]
        public void Test_ContainsNotExistingTransactionShouldBeFalse()
        {
            Assert.IsFalse(chainblock.Contains(transaction));
        }

        [Test]
        public void Test_ContainsExistingTransactionWithIdShouldBeTrue()
        {
            chainblock.Add(transaction);
            Assert.IsTrue(chainblock.Contains(transaction.Id));
        }

        [Test]
        public void Test_ContainsNotExistingTransactionWithIdShouldBeFalse()
        {
            Assert.IsFalse(chainblock.Contains(transaction.Id));
        }

        [Test]
        public void Test_ChangeTransactionStatusShouldChangeItToGiven()
        {
            chainblock.Add(transaction);
            chainblock.ChangeTransactionStatus(transaction.Id, TransactionStatus.Aborted);

            Assert.AreEqual(TransactionStatus.Aborted, chainblock.GetById(transaction.Id).Status);
        }

        [TestCase]
        public void Test_ChangeTransactionStatusWithInvalidIdShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(1, TransactionStatus.Aborted));
        }

        [Test]
        public void Test_RemoveTransactionByIdShouldRemoveIt()
        {
            chainblock.Add(transaction);
            chainblock.RemoveTransactionById(transaction.Id);

            Assert.IsFalse(chainblock.Contains(transaction));
        }

        [Test]
        public void Test_RemoveTransactionByIdShouldDecreaseCount()
        {
            chainblock.Add(transaction);
            chainblock.RemoveTransactionById(transaction.Id);

            Assert.AreEqual(0, chainblock.Count);
        }

        [Test]
        public void Test_RemoveTransactionByIdWithInvalidIdShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.RemoveTransactionById(1));
        }

        [Test]
        public void Test_GetByIdShouldReturnTransaction()
        {
            chainblock.Add(transaction);
            Assert.AreEqual(transaction, chainblock.GetById(transaction.Id));
        }

        [Test]
        public void Test_GetByIdWithNotExistingIdShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetById(transaction.Id));
        }

        [Test]
        public void Test_GetByTransactionStatusShouldReturnTransactionsByDescendingAmount()
        {
            CollectionAssert.AreEqual(transactions
                .Where(t => t.Status == TransactionStatus.Successful)
                .OrderByDescending(t => t.Amount), 
                filledChainblock.GetByTransactionStatus(TransactionStatus.Successful));
        }

        [Test]
        public void Test_GetByTransactionStatusWithoutMatchesShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByTransactionStatus(TransactionStatus.Successful));
        }

        [Test]
        public void Test_GetAllSendersWithTransactionStatusShouldReturnSendersWithGivenStatus()
        {
            CollectionAssert.AreEqual(transactions
                    .Where(t => t.Status == TransactionStatus.Successful)
                    .OrderByDescending(t => t.Amount)
                    .Select(t => t.From),
                filledChainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successful));
        }

        [Test]
        public void Test_GetAllSendersWithTransactionStatusWithoutMatchesShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successful));
        }

        [Test]
        public void Test_GetAllReceiversWithTransactionStatusShouldReturnSendersWithGivenStatus()
        {
            CollectionAssert.AreEqual(transactions
                    .Where(t => t.Status == TransactionStatus.Successful)
                    .OrderByDescending(t => t.Amount)
                    .Select(t => t.To),
                filledChainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successful));
        }

        [Test]
        public void Test_GetAllReceiversWithTransactionStatusWithoutMatchesShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successful));
        }

        [Test]
        public void Test_GetAllOrderedByAmountDescendingThenByIdShouldReturnOrderedCollection()
        {
            CollectionAssert.AreEqual(transactions
                    .OrderByDescending(t => t.Amount)
                    .ThenBy(t => t.Id),
                filledChainblock.GetAllOrderedByAmountDescendingThenById());
        }

        [Test]
        public void Test_GetBySenderOrderedByAmountDescendingShouldReturnOrderedTransactions()
        {
            CollectionAssert.AreEqual(transactions
                    .Where(t => t.From == "asdf")
                    .OrderByDescending(t => t.Amount),
                filledChainblock.GetBySenderOrderedByAmountDescending("asdf"));
        }

        [Test]
        public void Test_GetBySenderOrderedByAmountDescendingWithoutMatchesShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderOrderedByAmountDescending("asdf"));
        }

        [Test]
        public void Test_GetByReceiverOrderedByAmountThenByIdShouldReturnOrderedTransactions()
        {
            CollectionAssert.AreEqual(transactions
                    .Where(t => t.To == "ghjkl")
                    .OrderByDescending(t => t.Amount)
                    .ThenBy(t => t.Id),
                filledChainblock.GetByReceiverOrderedByAmountThenById("ghjkl"));
        }

        [Test]
        public void Test_GetByReceiverOrderedByAmountThenByIdWithoutMatchesShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverOrderedByAmountThenById("ghjkl"));
        }

        [TestCase(999)]
        [TestCase(12)]
        [TestCase(0)]
        public void Test_GetByTransactionStatusAndMaximumAmountShouldReturnOrderedTransactionsOrEmpty(double maxAmount)
        {
            CollectionAssert.AreEqual(transactions
                    .Where(t => t.Status == TransactionStatus.Successful && t.Amount <= maxAmount)
                    .OrderByDescending(t => t.Amount),
                filledChainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successful, maxAmount));
        }

        [Test]
        public void Test_GetBySenderAndMinimumAmountDescendingShouldReturnOrderedTransactions()
        {
            CollectionAssert.AreEqual(transactions
                    .Where(t => t.From == "asdf" && t.Amount > 5)
                    .OrderByDescending(t => t.Amount),
                filledChainblock.GetBySenderAndMinimumAmountDescending("asdf", 5));
        }

        [Test]
        public void Test_GetBySenderAndMinimumAmountDescendingWithoutMatchesShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => filledChainblock.GetBySenderAndMinimumAmountDescending("asdf", 5000));
        }

        [Test]
        public void Test_GetByReceiverAndAmountRangeShouldReturnOrderedTransactions()
        {
            CollectionAssert.AreEqual(transactions
                    .Where(t => t.To == "ghjkl" && t.Amount >= 1 && t.Amount < 69)
                    .OrderByDescending(t => t.Amount),
                filledChainblock.GetByReceiverAndAmountRange("ghjkl", 1, 69));
        }

        [Test]
        public void Test_GetByReceiverAndAmountRangeWithoutMatchesShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => filledChainblock.GetByReceiverAndAmountRange("ghjkl", 70, 1));
        }

        [TestCase(3, 70)]
        [TestCase(0.1, 420)]
        [TestCase(500, -1)]
        public void Test_GetAllInAmountRangeShouldReturnOrderedTransactions(double lo, double hi)
        {
            CollectionAssert.AreEqual(transactions.Where(t => t.Amount >= lo && t.Amount <= hi),
                filledChainblock.GetAllInAmountRange(lo, hi));
        }
    }
}