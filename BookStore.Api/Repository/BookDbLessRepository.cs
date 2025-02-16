using BookStore.Api;

namespace Bookstore.Api.Repository
{
    public class BookDbLessRepository
    {
        List<Book> books = new List<Book>()
        {
            new Book
                {
                    Id = 1,
                    Name = "Learning C#",
                    Description = "This book will give deep insights about C#.",
                    Price = 1000,
                    DisLikes = 10,
                    Likes = 100,
                },

                new Book
                {
                    Id = 2,
                    Name = "Learning Testing",
                    Description = "This is for teaching from basic to advance level of testing.",
                    Price = 1200,
                    DisLikes = 13,
                    Likes = 67,
                },

                new Book
                {
                    Id = 3,
                    Name = "Mastering Unit Testing in .NET Core",
                    Description = "This is a series in which every framework of Unit testing will be explained",
                    Price = 500,
                    DisLikes = 0,
                    Likes = 100,
                }
        };


        public async Task<Book> DeleteBook(int id)
        {
            var book = books.Where(a => a.Id == id).FirstOrDefault();
            if (book is null)
                throw new InvalidOperationException("Id passed is not Present");
            books.Remove(book);
            return await Task.Run(() => book);
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await Task.Run(() => books.ToList());
        }

        public async Task<Book> GetBook(int id)
        {
            var book = books.FirstOrDefault(a => a.Id == id);
            if (book is null)
                throw new Exception("Id is incorrect");

            return await Task.Run(() => book);

        }

        public async Task<Book> PostBook(Book book)
        {
            books.Add(book);
            return await Task.Run(() => book);
        }

        public async Task<Book> PutBook(int id, Book book)
        {
            if (id != book.Id)
                throw new Exception("Id is Different");

            //Update the Book in List
            int indexToUpdate = books.FindIndex(b => b.Id == id);

            if (indexToUpdate != -1)
            {
                // Update the book's properties
                books[indexToUpdate].Price = book.Price;
                books[indexToUpdate].Description = book.Description;
                books[indexToUpdate].Likes = book.Likes;
                books[indexToUpdate].DisLikes = book.DisLikes;
                books[indexToUpdate].Name = book.Name;

                return await Task.FromResult(books[indexToUpdate]);
            }
            else
            {
                throw new Exception("Book not found");
            }

        }
    }
}