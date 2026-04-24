using BookLibrary.Data;
using BookLibrary.Models;

namespace BookLibrary.GraphQL;

public class Mutation
{
    public Book AddBook(string title, string genre, int year, int authorId)
    {
        var authorExists = LibraryData.Authors.Any(a => a.Id == authorId);
        if (!authorExists)
            throw new GraphQLException($"Author with id {authorId} does not exist.");

        var book = new Book
        {
            Id = LibraryData.Books.Max(b => b.Id) + 1,
            Title = title,
            Genre = genre,
            Year = year,
            AuthorId = authorId
        };
        LibraryData.Books.Add(book);
        return book;
    }

    public bool DeleteBook(int id)
    {
        var book = LibraryData.Books.FirstOrDefault(b => b.Id == id);
        if (book == null) return false;
        LibraryData.Books.Remove(book);
        return true;
    }

    public Author AddAuthor(string name)
    {
        var author = new Author
        {
            Id = LibraryData.Authors.Max(a => a.Id) + 1,
            Name = name
        };
        LibraryData.Authors.Add(author);
        return author;
    }

    public Book? UpdateBook( int id, string title)
    {
        var book = LibraryData.Books.FirstOrDefault(b => b.Id == id);
        if (book == null) return null;
        book.Title = title;
        return book;
    }
}

