using System.Collections.Generic;
using System.Linq;
using BusinessObjects.Entity;

public class CatalogManager
{
    private BookRepository _repo = new BookRepository();

    public IEnumerable<Book> GetCatalog()
    {
        return _repo.GetAll();
    }

    public IEnumerable<Book> GetCatalog(TypeBook type)
    {
        return _repo.GetAll().Where(b => b.Type == type);
    }

    public Book FindBook(int id)
    {
        return _repo.Get(id);
    }
}
