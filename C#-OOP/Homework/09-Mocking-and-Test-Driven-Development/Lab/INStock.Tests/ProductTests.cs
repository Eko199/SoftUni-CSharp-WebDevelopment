namespace INStock.Tests
{
    using System;

    using Contracts;

    using NUnit.Framework;

    public class ProductTests
    {
        private IProduct product;

        [TestCase("asdf", 12.01, 5)]
        [TestCase("a", 12.01, 5)]
        [TestCase("aaaaaaaaaaaaaaadnne546n5464hn3w34h4h", 12.01, 5)]
        [TestCase("asdf", 0.001, 5)]
        [TestCase("asdf", 999999999, 5)]
        [TestCase("asdf", 12.01, 0)]
        [TestCase("asdf", 12.01, 999999999)]
        public void Test_ConstructorShouldSetProps(string label, decimal price, int quantity)
        {
            product = new Product(label, price, quantity);

            Assert.AreEqual(product.Label, label);
            Assert.AreEqual(product.Price, price);
            Assert.AreEqual(product.Quantity, quantity);
        }
        
        [TestCase(null, 12.01, 5)]
        [TestCase("", 12.01, 5)]
        [TestCase(" ", 12.01, 5)]
        [TestCase("                    ", 12.01, 5)]
        [TestCase("asdf", -999999999, 5)]
        [TestCase("asdf", -0.00001, 5)]
        [TestCase("asdf", 0, 5)]
        [TestCase("asdf", 12.01, -1)]
        [TestCase("asdf", 12.01, -9999999)]
        public void Test_ConstructorWithInvalidArgumentsShouldThrow(string label, decimal price, int quantity)
        {
            Assert.Throws<ArgumentException>(() => product = new Product(label, price, quantity));
        }
    }
}