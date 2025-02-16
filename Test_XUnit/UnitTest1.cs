using Bookstore.Api.Repository;

namespace Test_XUnit
{
    public class BookTests
    {
        BookDbLessRepository books;

        public BookTests()
        {
            // Set up common resources or logic before each test
            books = new BookDbLessRepository();
        }

        [Fact]
        public void GetBooks()
        {
            var count = books.GetBooks().Result.Count();

            Assert.Equal(3, count);
        }


    }
}