using System;
using System.Linq;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        // 1. Créer le host avec la configuration des services
        var host = CreateHostBuilder();

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
                // Enregistrement des repositories (Transient)
                services.AddTransient<IGenericRepository<Book>, BookRepository>();

                // Compatibilité : si d'autres parties du code demandent IBookRepository
                services.AddTransient<IBookRepository>(sp => (IBookRepository)sp.GetRequiredService<IGenericRepository<Book>>());

                // Enregistrement du manager
                services.AddTransient<ICatalogManager, CatalogManager>();
            })
            .Build();
    }
}

