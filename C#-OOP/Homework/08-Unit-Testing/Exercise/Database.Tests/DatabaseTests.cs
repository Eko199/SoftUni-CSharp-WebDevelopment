namespace Database.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;

        [SetUp]
        public void SetUp()
        {
            db = new Database();
        }

        [TestCase(new int[] {})]
        [TestCase(new int[] { 1, 2, 3})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]
        public void Test_DbConstructorShouldSetCorrectCount(int[] elements)
        {
            db = new Database(elements);
            Assert.AreEqual(elements.Length, db.Count);
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_DbConstructorShouldSetCorrectElements(int[] elements)
        {
            db = new Database(elements);
            CollectionAssert.AreEqual(elements, db.Fetch());
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 1, 1, 1, 1, 1 })]
        public void Test_DbConstructorWithMoreThan16ElementsShouldThrow(int[] elements)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db = new Database(elements);
            });
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(16)]
        public void Test_EmptyDbAddShouldIncreaseCount(int times)
        {
            for (int i = 0; i < times; i++)
            {
                db.Add(i);
            }

            Assert.AreEqual(times, db.Count);
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(13)]
        public void Test_ExistingDbAddShouldIncreaseCount(int times)
        {
            db = new Database(1, 2, 3);

            for (int i = 0; i < times; i++)
            {
                db.Add(i);
            }

            Assert.AreEqual(times + 3, db.Count);
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_EmptyDbAddShouldAddElements(int[] elements)
        {
            foreach (int element in elements)
            {
                db.Add(element);
            }

            CollectionAssert.AreEqual(elements, db.Fetch());
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 })]
        public void Test_ExistingDbAddShouldAddElements(int[] elements)
        {
            db = new Database(1, 2);
            int[] result = new int[db.Count + elements.Length];

            result[0] = 1;
            result[1] = 2;

            for (var i = 0; i < elements.Length; i++)
            {
                result[2 + i] = elements[i];
                db.Add(elements[i]);
            }

            CollectionAssert.AreEqual(result, db.Fetch());
        }

        [TestCase(17)]
        [TestCase(90)]
        public void Test_DbAddAtCount16ShouldThrow(int count)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    db.Add(i);
                }
            });
        }

        [Test]
        public void Test_FullDbAddShouldThrow()
        {
            db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(1);
            });
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        public void Test_DbRemoveShouldDecreaseCount(int times)
        {
            db = new Database(1, 2, 3, 4);
            int originalCount = db.Count;

            for (int i = 0; i < times; i++)
            {
                db.Remove();
            }

            Assert.AreEqual(originalCount - times, db.Count);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        public void Test_ExistingDbRemoveShouldRemoveElements(int times)
        {
            db = new Database(1, 2, 3, 4);
            int[] result = { 1, 2, 3, 4};

            for (var i = 0; i < times; i++)
            {
                db.Remove();
            }

            CollectionAssert.AreEqual(result[..^times], db.Fetch());
        }

        [Test]
        public void Test_EmptyDbRemoveShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            });
        }

        [Test]
        public void Test_DbFetchShouldReturnAnArray()
        {
            db = new Database(1, 2, 3, 4);
            Assert.IsInstanceOf<int[]>(db.Fetch());
        }
    }
}
