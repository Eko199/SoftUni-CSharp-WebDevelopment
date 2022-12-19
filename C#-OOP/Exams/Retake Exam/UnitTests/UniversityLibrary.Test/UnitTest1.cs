namespace UniversityLibrary.Test
{
    using System.Collections.Generic;

    using NUnit.Framework;

    public class Tests
    {
        private TextBook textBook;
        private UniversityLibrary library;

        [SetUp]
        public void Setup()
        {
            textBook = new TextBook("asdf", "az", "poetika");
            library = new UniversityLibrary();
        }

        [Test]
        public void Test_ConstructorShouldCreateEmptyLibrary()
        {
            CollectionAssert.AreEqual(new List<TextBook>(), library.Catalogue);
        }

        [Test]
        public void Test_AddTextBookToLibraryShouldAddItToTheCatalogue()
        {
            library.AddTextBookToLibrary(textBook);
            CollectionAssert.AreEqual(new List<TextBook> { textBook }, library.Catalogue);
        }

        [Test]
        public void Test_CatalogueShouldContainAddedBooks()
        {
            library.AddTextBookToLibrary(textBook);
            Assert.AreEqual(textBook, library.Catalogue[0]);
        }

        [Test]
        public void Test_AddTextBookToLibraryShouldSetItsInventoryNumber()
        {
            library.AddTextBookToLibrary(textBook);
            Assert.AreEqual(textBook.InventoryNumber, library.Catalogue.Count);
        }

        [Test]
        public void Test_AddTextBookToLibraryShouldReturnBookToString()
        {
            string result = library.AddTextBookToLibrary(textBook);
            Assert.AreEqual(textBook.ToString(), result);
        }

        [Test]
        public void Test_LoanTextBookShouldChangeItsHolderName()
        {
            const string student = "az";

            library.AddTextBookToLibrary(textBook);
            library.LoanTextBook(1, student);

            Assert.AreEqual(student, textBook.Holder);
        }

        [Test]
        public void Test_LoanTextBookShouldReturnMessage()
        {
            const string student = "az";
            library.AddTextBookToLibrary(textBook);

            Assert.AreEqual($"{textBook.Title} loaned to {student}.", library.LoanTextBook(1, student));
        }

        [Test]
        public void Test_LoanAlreadyLoanedTextBookShouldReturnErrorMessage()
        {
            const string student = "az";
            library.AddTextBookToLibrary(textBook);
            library.LoanTextBook(1, student);

            Assert.AreEqual($"{student} still hasn't returned {textBook.Title}!", library.LoanTextBook(1, student));
        }

        [Test]
        public void Test_ReturnTextBookShouldEmptyBookHolder()
        {
            textBook.Holder = "asdafsdf";
            library.AddTextBookToLibrary(textBook);
            library.ReturnTextBook(1);

            Assert.AreEqual(string.Empty, textBook.Holder);
        }

        [Test]
        public void Test_ReturnTextBookShouldReturnMessage()
        {
            library.AddTextBookToLibrary(textBook);
            Assert.AreEqual($"{textBook.Title} is returned to the library.", library.ReturnTextBook(1));
        }
    }
}