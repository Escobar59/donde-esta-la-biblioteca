using System.Collections.Generic;

public interface ICatalogManager
{
    IEnumerable<Book> GetCatalog();
    IEnumerable<Book> GetCatalog(TypeBook type);
    Book FindBook(int id);
}