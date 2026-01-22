using System;
using System.Linq;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        // 1. Créer le host avec la configuration des services
        var host = CreateHostBuilder();

        // Seeding de la base de données
        using (var scope = host.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<LibraryContext>();
            context.Database.EnsureCreated();
            if (!context.Authors.Any())
            {
                var author1 = new Author { Id = 1, FirstName = "Alexandre", LastName = "Dumas" };
                var author2 = new Author { Id = 2, FirstName = "Victor", LastName = "Hugo" };
                context.Authors.AddRange(author1, author2);
                context.Books.AddRange(
                    new Book { Id = 1, Name = "Le conte de Monte Cristo", Pages = 900, Rate = 5, Type = TypeBook.Aventure, AuthorId = 1 },
                    new Book { Id = 2, Name = "Le Petit Prince", Pages = 96, Rate = 4, Type = TypeBook.Fantaisie, AuthorId = 2 },
                    new Book { Id = 3, Name = "Indiana Jones", Pages = 320, Rate = 4, Type = TypeBook.Aventure, AuthorId = 1 }
                );
                context.Libraries.AddRange(
                    new Library { Id = 1, Name = "Bibliothèque Roubaix", Address = "44 Av. Jean Lebas, 59100 Roubaix" },
                    new Library { Id = 2, Name = "Bibliothèque Centrale", Address = "1 Place Centrale" }
                );
                context.SaveChanges();
            }
        }

        // 2. Récupérer le service depuis le conteneur DI
        ICatalogManager catalogManager = host.Services.GetRequiredService<ICatalogManager>();

        // 3. Utiliser le service (les dépendances sont automatiquement injectées)
        var adventureBooks = catalogManager.GetCatalog(TypeBook.Aventure);

        foreach (var book in adventureBooks)
        {
            Console.WriteLine(book.Name);
        }
    }

    private static IHost CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                // Enregistrement du DbContext
                services.AddDbContext<LibraryContext>(options =>
                {
                    string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "library.db");
                    options.UseSqlite($"Data Source={dbPath}");
                });

                // Enregistrement des repositories (Transient)
                services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

                // Compatibilité : si d'autres parties du code demandent IBookRepository
                services.AddTransient<IBookRepository>(sp => (IBookRepository)sp.GetRequiredService<IGenericRepository<Book>>());

                // Enregistrement du manager
                services.AddTransient<ICatalogManager, CatalogManager>();
            })
            .Build();
    }
}

