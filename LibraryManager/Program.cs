using System;
using System.Linq;
using BusinessObjects.Entity;

class Program
{
    static void Main(string[] args)
    {
        var repo = new BookRepository();
        var books = repo.GetAll();

        var adventureBooks = books.Where(book => book.Type == TypeBook.Aventure);
        foreach (var book in adventureBooks)
        {
            Console.WriteLine(book.Name);
        }
    }
}