namespace DatabaseExtended.Tests
{
    using System;

    using ExtendedDatabase;

    using NUnit.Framework;
    
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person[] people;
        private Database db;

        [SetUp]
        public void SetUp()
        {
            people = new Person[20];

            for (int i = 0; i < 20; i++)
            {
                people[i] = new Person(i, ((char)('a'+i)).ToString());
            }

            db = new Database();
        }

        [TestCase(0)]
        [TestCase(3)]
        [TestCase(16)]
        public void Test_DbConstructorShouldSetCorrectCount(int count)
        {
            db = new Database(people[..count]);
            Assert.AreEqual(count, db.Count);
        }

        [Test]
        public void Test_DbConstructorShouldSetCorrectElements()
        {
            db = new Database(people[0]);
            Assert.AreEqual(people[0], db.FindById(people[0].Id));
        }

        [TestCase(17)]
        [TestCase(20)]
        public void Test_DbConstructorWithMoreThan16PeopleShouldThrow(int count)
        {
            Assert.Throws<ArgumentException>(() => db = new Database(people[..count]));
        }

        [Test]
        public void TestDbConstructorWithPeopleWithIdenticalIdShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => db = new Database(people[0], new Person(people[0].Id, "az")));
        }

        [Test]
        public void TestDbConstructorWithPeopleWithIdenticalUsernameShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => db = new Database(people[0], new Person(99, people[0].UserName)));
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(16)]
        public void Test_EmptyDbAddShouldIncreaseCount(int times)
        {
            for (int i = 0; i < times; i++)
            {
                db.Add(people[i]);
            }

            Assert.AreEqual(times, db.Count);
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(14)]
        public void Test_ExistingDbAddShouldIncreaseCount(int times)
        {
            db = new Database(people[0], people[1]);
            int originalCount = db.Count;

            for (int i = 0; i < times; i++)
            {
                db.Add(people[i+2]);
            }

            Assert.AreEqual(times + originalCount, db.Count);
        }

        [Test]
        public void Test_EmptyDbAddShouldAddElements()
        {
            db.Add(people[0]);
            Assert.AreEqual(people[0], db.FindById(people[0].Id));
        }

        [TestCase(17)]
        [TestCase(20)]
        public void Test_DbAddAtCount16ShouldThrow(int count)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < count; i++)
                {
                    db.Add(people[i]);
                }
            });
        }

        [Test]
        public void Test_FullDbAddShouldThrow()
        {
            db = new Database(people[..^16]);

            Assert.Throws<InvalidOperationException>(() => db.Add(people[0]));
        }

        [Test]
        public void TestDbAddPersonWithExistingIdShouldThrow()
        {
            db = new Database(people[0]);
            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(people[0].Id, "az")));
        }

        [Test]
        public void TestDbAddPersonWithExistingUsernameShouldThrow()
        {
            db = new Database(people[0]);
            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(99, people[0].UserName)));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        public void Test_DbRemoveShouldDecreaseCount(int count)
        {
            db = new Database(people[0], people[1], people[2], people[3]);
            int originalCount = db.Count;

            for (int i = 0; i < count; i++)
            {
                db.Remove();
            }

            Assert.AreEqual(originalCount - count, db.Count);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        public void Test_ExistingDbRemoveShouldRemoveElements(int count)
        {
            db = new Database(people[0], people[1], people[2], people[3]);

            for (var i = 0; i < count; i++)
            {
                db.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => db.FindById(people[4-count].Id));
        }

        [Test]
        public void Test_EmptyDbRemoveShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        public void Test_DbFindByUsernameShouldReturnThePerson()
        {
            db = new Database(people[0]);
            Assert.AreEqual(people[0], db.FindByUsername(people[0].UserName));
        }

        [Test]
        public void Test_DbFindByUsernameWithWrongUsernameShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername(people[0].UserName));
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_DbFindByUsernameWithEmptyOrNullUsernameShouldThrow(string emptyOrNull)
        {
            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(emptyOrNull));
        }

        [Test]
        public void Test_DbFindByUsernameShouldBeCaseSensitiveAndThrow()
        {
            db = new Database(people[0]);
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername(people[0].UserName.ToUpper()));
        }

        [Test]
        public void Test_DbFindByIdShouldReturnThePerson()
        {
            db = new Database(people[0]);
            Assert.AreEqual(people[0], db.FindById(people[0].Id));
        }

        [Test]
        public void Test_DbFindByIdWithWrongIdShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => db.FindById(people[0].Id));
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void Test_DbFindByUsernameWithEmptyOrNullUsernameShouldThrow(int negativeId)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(negativeId));
        }
    }
}