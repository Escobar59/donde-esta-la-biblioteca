using System.Collections.Generic;
using System.Linq;

public class CatalogManager : ICatalogManager
{
    private readonly IGenericRepository<Book> _repository;

    public CatalogManager(IGenericRepository<Book> repository) 
    {
        _repository = repository;
    }

    public IEnumerable<Book> GetCatalog()
    {
        return _repository.GetAll();
    }

    public IEnumerable<Book> GetCatalog(TypeBook type)
    {
        return _repository.GetAll().Where(i => i.Type == type);
    }

    public void AddBook(Book book)
    {
        _repository.Add(book);
    }

    public Book FindBook(int id)
    {
        return _repository.Get(id);
    }

    public Book Bestbookrated()
    {
        var books = _repository.GetAll().OrderByDescending(b => b.Rate).ToList();
        return books.FirstOrDefault();
    }
    public void Delete(int id)
    {
         _repository.Delete(id);
    }
}
