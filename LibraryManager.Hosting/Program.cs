using Microsoft.EntityFrameworkCore;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        /*
           The middleware added before the builder will be retrieved by the application.
        */
        // DbContext registration
        builder.Services.AddDbContext<LibraryContext>(options =>
        {
            string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "library.db");
            options.UseSqlite($"Data Source={dbPath}");
        });

        // Recording repositories
        builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        // Compatibility: if other parts of the code require iBookRepository
        builder.Services.AddTransient<IBookRepository>(sp => (IBookRepository)sp.GetRequiredService<IGenericRepository<Book>>());

        // Manager registration
        builder.Services.AddTransient<ICatalogManager, CatalogManager>();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}