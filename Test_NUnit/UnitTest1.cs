using Bookstore.Api.Repository;

namespace Test_NUnit
{
    public class BookTests
    {
        BookDbLessRepository books;

        [SetUp]
        public void Setup()
        {
            // Set up common resources or logic before each test
            books = new BookDbLessRepository();
        }

        [Test]
        public void GetBooks()
        {
            var count = books.GetBooks().Result.Count();

            Assert.That(3 == count);
        }
    }
}