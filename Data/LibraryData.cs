using BookLibrary.Models;

namespace BookLibrary.Data;

public static class LibraryData
{
    public static List<Author> Authors = new()
    {
        new Author { Id = 1, Name = "J.R.R. Tolkien" },
        new Author { Id = 2, Name = "George Orwell" }
    };

    public static List<Book> Books = new()
    {
        new Book { Id = 1, Title = "The Hobbit", Genre = "Fantasy", Year = 1937, AuthorId = 1 },
        new Book { Id = 2, Title = "1984", Genre = "Dystopia", Year = 1949, AuthorId = 2 },
        new Book { Id = 3, Title = "Animal Farm", Genre = "Satire", Year = 1945, AuthorId = 2 }
    };
}
