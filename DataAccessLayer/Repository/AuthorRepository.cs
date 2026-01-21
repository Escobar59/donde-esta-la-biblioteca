using System.Collections.Generic;

public class AuthorRepository
{
    private List<Author> _authors;

    public AuthorRepository()
    {
        _authors = new List<Author>
            {
                new Author { Id = 1, FirstName = "Alexandre", LastName = "Dumas" },
                new Author { Id = 2, FirstName = "Victor", LastName = "Hugo" }
            };
    }

    public IEnumerable<Author> GetAll() => _authors;

    public Author Get(int id) => _authors.Find(a => a.Id == id);
}

