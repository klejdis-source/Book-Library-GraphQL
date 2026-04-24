using BookLibrary.Data;
using BookLibrary.Models;

namespace BookLibrary.GraphQL
{
    public class Query
    {
        public List<Book> GetBooks(string? genre = null) =>
            genre == null
                ? LibraryData.Books
                : LibraryData.Books.Where(b => b.Genre == genre).ToList();

        public Book? GetBook(int id) =>
            LibraryData.Books.FirstOrDefault(b => b.Id == id);

        public List<Author> GetAuthors() => LibraryData.Authors;

        public Author? GetAuthor(int id)
        {
            var author = LibraryData.Authors.FirstOrDefault(a => a.Id == id);
            if (author == null) return null;
            author.Books = LibraryData.Books.Where(b => b.AuthorId == id).ToList();
            return author;
        }

    }
}
