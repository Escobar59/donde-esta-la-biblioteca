class Program
{
    static void Main(string[] args)
    {
        List<Book> books = new List<Book>
        {
            new Book { Name = "Le Seigneur des Anneaux", Type = "Fantaisie" },
            new Book { Name = "Harry Potter", Type = "Fantaisie" },
            new Book { Name = "Indiana Jones", Type = "Aventure" }
        };

        foreach (var book in books)
        {
            Console.WriteLine(book.Name);
        }
    }
}

class Book
{
    public string Name { get; set; }
    public string Type { get; set; }
}