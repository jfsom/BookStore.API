using Bookstore.Api.Repository;

namespace Test_MSUnit
{
    [TestClass]
    public class BookTests
    {
        BookDbLessRepository books;

        [TestInitialize]
        public void TestInitialize()
        {
            // Set up common resources or logic before each test
            books = new BookDbLessRepository();
        }

        [TestMethod]
        public void GetBooks()
        {
            var count = books.GetBooks().Result.Count();

            Assert.AreEqual(3, count);
        }
    }
}
