using System;
using System.Linq;
using BusinessObjects.Entity;
using Services.Services;

class Program
{
    static void Main(string[] args)
    {
        var manager = new CatalogManager();
        var adventureBooks = manager.GetCatalog(TypeBook.Aventure);
        foreach (var book in adventureBooks)
        {
            Console.WriteLine(book.Name);
        }
    }
}