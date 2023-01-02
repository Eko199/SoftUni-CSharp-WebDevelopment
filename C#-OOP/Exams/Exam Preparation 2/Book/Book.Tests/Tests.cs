namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        private const string BookName = "asdf", BookAuthor = "Az";

        private Book book;

        [SetUp]
        public void SetUp()
        {
            book = new Book(BookName, BookAuthor);
        }

        [Test]
        public void Test_ConstructorShouldSetFieldsProperly()
        {
            Assert.AreEqual(BookName, book.BookName);
            Assert.AreEqual(BookAuthor, book.Author);
            Assert.AreEqual(0, book.FootnoteCount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_ConstructorWithNullOrEmptyNameShouldThrow(string name)
        {
            Assert.Throws<ArgumentException>(() => book = new Book(name, BookAuthor));
        }

        [TestCase(null)]
        [TestCase("")]
        public void Test_ConstructorWithNullOrEmptyAuthorShouldThrow(string author)
        {
            Assert.Throws<ArgumentException>(() => book = new Book(BookName, author));
        }

        [Test]
        public void Test_AddFootnoteShouldIncreaseCount()
        {
            book.AddFootnote(1, "aaaa");
            Assert.AreEqual(1, book.FootnoteCount);
        }

        [Test]
        public void Test_AddExistingFootnoteShouldThrow()
        {
            book.AddFootnote(1, "aaaa");
            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(1, "awerfg"));
        }

        [Test]
        public void Test_FindFootnoteShouldReturnFootnote()
        {
            book.AddFootnote(1, "aaaa");
            Assert.AreEqual("Footnote #1: aaaa", book.FindFootnote(1));
        }

        [Test]
        public void Test_FindNotExistingFootnoteShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(1));
        }

        [Test]
        public void Test_AlterFootnoteShouldChangeText()
        {
            book.AddFootnote(1, "bsdf");
            book.AlterFootnote(1, "aaaa");

            Assert.AreEqual("Footnote #1: aaaa", book.FindFootnote(1));
        }

        [Test]
        public void Test_AlterNotExistingFootnoteShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(1, "asdfdf"));
        }
    }
}