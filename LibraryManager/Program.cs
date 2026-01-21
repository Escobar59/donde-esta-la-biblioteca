using System;
using System.Linq;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        var host = CreateHostBuilder();
        using var serviceScope = host.Services.CreateScope();
        var services = serviceScope.ServiceProvider;

        // Récupération du service via l'interface
        var manager = services.GetRequiredService<ICatalogManager>();
        var adventureBooks = manager.GetCatalog(TypeBook.Aventure);
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
                // Enregistrement du repository générique et compatibilité IBookRepository
                services.AddSingleton<IGenericRepository<Book>, BookRepository>();
                services.AddSingleton<IBookRepository>(sp => (IBookRepository)sp.GetRequiredService<IGenericRepository<Book>>());

                services.AddScoped<ICatalogManager, CatalogManager>();
            })
            .Build();
    }
}

