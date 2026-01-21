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

    public Book FindBook(int id)
    {
        return _repository.Get(id);
    }
}
