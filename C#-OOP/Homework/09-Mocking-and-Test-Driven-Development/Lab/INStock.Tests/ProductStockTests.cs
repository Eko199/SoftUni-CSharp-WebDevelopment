namespace INStock.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    using NUnit.Framework;

    [TestFixture]
    public class ProductStockTests
    {
        private IProduct product;
        private IProductStock productStock;

        [SetUp]
        public void SetUp()
        {
            product = new Product("asdf", 12.3M, 10);
            productStock = new ProductStock();
        }

        [Test]
        public void Test_ConstructorShouldCreateEmptyProductStock()
        {
            Assert.AreEqual(0, productStock.Count);
        }

        [Test]
        public void Test_AddShouldIncreaseCount()
        {
            productStock.Add(product);
            Assert.AreEqual(1, productStock.Count);
        }

        [Test]
        public void Test_AddExistingProductShouldThrow()
        {
            productStock.Add(product);
            Assert.Throws<InvalidOperationException>(() => productStock.Add(product));
        }

        [Test]
        public void Test_ContainsExistingProductShouldBeTrue()
        {
            productStock.Add(product);
            Assert.IsTrue(productStock.Contains(product));
        }

        [Test]
        public void Test_ContainsNotExistingProductShouldBeFalse()
        {
            Assert.IsFalse(productStock.Contains(product));
        }

        [Test]
        public void Test_FindShouldReturnProduct()
        {
            productStock.Add(product);
            Assert.AreEqual(product, productStock.Find(0));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        [TestCase(100)]
        public void Test_FindWithInvalidIndexShouldThrow(int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() => productStock.Find(index));
        }

        [Test]
        public void Test_FindByLabelShouldReturnProduct()
        {
            productStock.Add(product);
            Assert.AreEqual(product, productStock.FindByLabel(product.Label));
        }

        [Test]
        public void Test_FindByNotExistingLabelShouldThrow()
        {
            productStock.Add(product);
            Assert.Throws<ArgumentException>(() => productStock.FindByLabel("wrtbhjietw4ggiy78egrstv"));
        }

        [TestCase(5, 6)]
        [TestCase(1, 200)]
        [TestCase(100, 0)]
        [TestCase(10, 10)]
        public void Test_FindAllInPriceRangeShouldReturnCollectionInDescendingOrder(decimal p1, decimal p2)
        {
            var products = new List<IProduct>();

            for (decimal i = 15.5M; i >= 5.5M; i--)
            {
                product = new Product(i.ToString(), i, 1);
                productStock.Add(product);
                products.Add(product);
            }

            CollectionAssert.AreEqual(products.Where(p => p.Price >= p1 && p.Price <= p2), productStock.FindAllInRange(p1, p2));
        }

        [TestCase(0.5)]
        [TestCase(-10)]
        [TestCase(10)]
        [TestCase(15.5)]
        [TestCase(9999.5)]
        public void Test_FindAllByPriceShouldReturnCollectionOfProducts(decimal price)
        {
            var products = new List<IProduct>();

            for (decimal i = 0.5M; i <= 15.5M; i++)
            {
                product = new Product(i.ToString(), i, 1);
                IProduct product1 = new Product((1000+i).ToString(), i, 1);

                productStock.Add(product);
                productStock.Add(product1);

                products.Add(product);
                products.Add(product1);
            }

            CollectionAssert.AreEqual(products.Where(p => p.Price == price), productStock.FindAllByPrice(price));
        }


        [Test]
        public void Test_FindMostExpensiveProductShouldReturnProductWithBiggestPrice()
        {
            for (decimal i = 0.5M; i <= 15.5M; i++)
            {
                product = new Product(i.ToString(), i, 1);
                productStock.Add(product);
            }

            Assert.AreEqual(product, productStock.FindMostExpensiveProduct());
        }
        
        [Test]
        public void Test_FindMostExpensiveProductInEmptyStockShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => productStock.FindMostExpensiveProduct());
        }

        [TestCase(-100)]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(15)]
        [TestCase(9999)]
        public void Test_FindAllByQuantityShouldReturnCollectionOfProducts(int quantity)
        {
            var products = new List<IProduct>();

            for (int i = 0; i <= 15; i++)
            {
                product = new Product(i.ToString(), 12.5M, i);
                IProduct product1 = new Product((1000 + i).ToString(), 12.5M, i);

                productStock.Add(product);
                productStock.Add(product1);

                products.Add(product);
                products.Add(product1);
            }

            CollectionAssert.AreEqual(products.Where(p => p.Quantity == quantity), productStock.FindAllByQuantity(quantity));
        }

        [Test]
        public void Test_IndexerGetterShouldReturnIndexedProduct()
        {
            var products = new List<IProduct>();

            for (int i = 0; i <= 10; i++)
            {
                product = new Product(i.ToString(), 12.5M, i);
                productStock.Add(product);
                products.Add(product);
            }

            Assert.AreEqual(products[0], productStock[0]);
        }

        [TestCase(-1)]
        [TestCase(-100)]
        [TestCase(11)]
        [TestCase(9999)]
        public void Test_IndexerGetterOutsideOfRangeShouldThrow(int index)
        {
            for (int i = 0; i <= 10; i++)
            {
                productStock.Add(new Product(i.ToString(), 12.5M, i));
            }

            Assert.Throws<IndexOutOfRangeException>(() => productStock[index].ToString());
        }

        [Test]
        public void Test_IndexerSetterShouldSetIndexedProduct()
        {
            for (int i = 0; i <= 10; i++)
            {
                productStock.Add(new Product(i.ToString(), 12.5M, i));
            }

            productStock[0] = product;

            Assert.AreEqual(product, productStock[0]);
        }

        [TestCase(-1)]
        [TestCase(-100)]
        [TestCase(11)]
        [TestCase(9999)]
        public void Test_IndexerSetterOutsideOfRangeShouldThrow(int index)
        {
            for (int i = 0; i <= 10; i++)
            {
                productStock.Add(new Product(i.ToString(), 12.5M, i));
            }

            Assert.Throws<IndexOutOfRangeException>(() => productStock[index] = product);
        }
    }
}
