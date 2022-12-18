namespace Chainblock.Tests
{
    using System;
    using NUnit.Framework;
    [TestFixture]
    public class TransactionTests
    {
        private Transaction transaction;

        [SetUp]
        public void StartUp()
        {
            transaction = new Transaction(1, TransactionStatus.Successful, "asdf", "asdf", 10.5);
        }

        [TestCase(10, "asdf", "asdf", 10.5)]
        [TestCase(1, "asdf", "asdf", 10.5)]
        [TestCase(99999, "asdf", "asdf", 10.5)]
        [TestCase(10, "asdfafdddddddddddddd", "asdf", 10.5)]
        [TestCase(10, "a", "asdf", 10.5)]
        [TestCase(10, "asdf", "asdfafdddddddddddddd", 10.5)]
        [TestCase(10, "asdf", "a", 10.5)]
        [TestCase(10, "asdf", "aasdf", 1)]
        [TestCase(10, "asdf", "aasdf", 0.0001)]
        [TestCase(10, "asdf", "aasdf", 9999999999.99)]
        public void Test_ConstructorShouldSetFieldsProperly(int id, string from, string to,
            double amount)
        {
            transaction = new Transaction(id, TransactionStatus.Successful, from, to, amount);

            Assert.AreEqual(id, transaction.Id);
            Assert.AreEqual(TransactionStatus.Successful, transaction.Status);
            Assert.AreEqual(from, transaction.From);
            Assert.AreEqual(to, transaction.To);
            Assert.AreEqual(amount, transaction.Amount);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-999999)]
        public void Test_ConstructorWith0OrNegativeIdShouldThrow(int id)
        {
            Assert.Throws<ArgumentException>(() =>
                transaction = new Transaction(id, TransactionStatus.Successful, "asdf", "asdf", 10.5));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-999999)]
        public void Test_Set0OrNegativeIdShouldThrow(int id)
        {
            Assert.Throws<ArgumentException>(() => transaction.Id = id);
        }

        [TestCase(2)]
        [TestCase(100)]
        [TestCase(999999)]
        public void Test_IdSetShouldSetIt(int id)
        {
            transaction.Id = id;
            Assert.AreEqual(id, transaction.Id);
        }

        [Test]
        public void Test_TransactionStatusSetShouldSetIt()
        {
            transaction.Status = TransactionStatus.Aborted;
            Assert.AreEqual(TransactionStatus.Aborted, transaction.Status);
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("         ")]
        public void Test_ConstructorWithNullOrWhiteSpaceFromShouldThrow(string to)
        {
            Assert.Throws<ArgumentException>(() =>
                transaction = new Transaction(1, TransactionStatus.Successful, to, "asdf", 10.5));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("         ")]
        public void Test_SetNullOrWhiteSpaceFromShouldThrow(string from)
        {
            Assert.Throws<ArgumentException>(() => transaction.From = from);
        }

        [TestCase("a")]
        [TestCase("asd")]
        [TestCase("asddfdfsaasdfdfassdfsdf")]
        public void Test_SetFromShouldSetIt(string from)
        {
            transaction.From = from;
            Assert.AreEqual(from, transaction.From);
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("         ")]
        public void Test_ConstructorWithNullOrWhiteSpaceToShouldThrow(string to)
        {
            Assert.Throws<ArgumentException>(() =>
                transaction = new Transaction(1, TransactionStatus.Successful, "asdf", to, 10.5));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("         ")]
        public void Test_SetNullOrWhiteSpaceToShouldThrow(string to)
        {
            Assert.Throws<ArgumentException>(() => transaction.To = to);
        }

        [TestCase("a")]
        [TestCase("asd")]
        [TestCase("asddfdfsaasdfdfassdfsdf")]
        public void Test_SetToShouldSetIt(string to)
        {
            transaction.To = to;
            Assert.AreEqual(to, transaction.To);
        }

        [TestCase(0)]
        [TestCase(-0.0000001)]
        [TestCase(-999999.9)]
        public void Test_ConstructorWith0OrNegativeAmountShouldThrow(double amount)
        {
            Assert.Throws<ArgumentException>(() =>
                transaction = new Transaction(1, TransactionStatus.Successful, "asdf", "asdf", amount));
        }

        [TestCase(0)]
        [TestCase(-0.0000001)]
        [TestCase(-999999.9)]
        public void Test_Set0OrNegativeAmountShouldThrow(double amount)
        {
            Assert.Throws<ArgumentException>(() => transaction.Amount = amount);
        }

        [TestCase(0.1)]
        [TestCase(100)]
        [TestCase(999999.9)]
        public void Test_AmountSetShouldSetIt(double amount)
        {
            transaction.Amount = amount;
            Assert.AreEqual(amount, transaction.Amount);
        }
    }
}