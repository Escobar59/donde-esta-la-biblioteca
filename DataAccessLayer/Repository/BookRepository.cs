using System.Collections.Generic;
using BusinessObjects.Entity;

public class BookRepository
{
    private List<Book> _books;

    public BookRepository()
    {
        _books = new List<Book>
            {
                new Book { Id = 1, Name = "Le conte de Monte Cristo", Pages = 900, Rate = 5, Type = TypeBook.Aventure, AuthorId = 1, Author = new Author { Id = 1, FirstName = "Alexandre", LastName = "Dumas" } },
                new Book { Id = 2, Name = "Le Petit Prince", Pages = 96, Rate = 4, Type = TypeBook.Fantaisie, AuthorId = 2, Author = new Author { Id = 2, FirstName = "Victor", LastName = "Hugo" } },
                new Book { Id = 3, Name = "Indiana Jones", Pages = 320, Rate = 4, Type = TypeBook.Aventure, AuthorId = 1, Author = new Author { Id = 1, FirstName = "Alexandre", LastName = "Dumas" } }
            };
    }

    public IEnumerable<Book> GetAll() => _books;

    public Book Get(int id) => _books.Find(b => b.Id == id);
}