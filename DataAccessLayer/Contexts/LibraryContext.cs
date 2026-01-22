using Microsoft.EntityFrameworkCore;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) 
        : base(options)
    {
    }

    // DbSet : Représente une table de la base de données
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Library> Libraries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuration des relations One-to-Many : Author -> Books
        modelBuilder.Entity<Author>()
            .HasMany(a => a.Books)
            .WithOne(b => b.Author)
            .HasForeignKey(b => b.AuthorId);
            
        // Configuration des relations Many-to-Many : Library <-> Books
        modelBuilder.Entity<Library>()
            .HasMany(l => l.Books)
            .WithMany(b => b.Libraries)
            .UsingEntity(j => j.ToTable("library_books"));
    }
}