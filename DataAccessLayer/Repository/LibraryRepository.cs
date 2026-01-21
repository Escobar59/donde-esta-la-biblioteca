using System.Collections.Generic;

public class LibraryRepository
{
    private List<Library> _libraries;

    public LibraryRepository()
    {
        _libraries = new List<Library>
            {
                new Library { Id = 1, Name = "Bibliothèque Roubaix", Address = "44 Av. Jean Lebas, 59100 Roubaix", Books = new List<Book>() },
                new Library { Id = 2, Name = "Bibliothèque Centrale", Address = "1 Place Centrale", Books = new List<Book>() }
            };
    }

    public IEnumerable<Library> GetAll() => _libraries;

    public Library Get(int id) => _libraries.Find(l => l.Id == id);
}