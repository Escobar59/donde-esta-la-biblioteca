using Microsoft.EntityFrameworkCore;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) 
        : base(options)
    {
    }

    // DbSet : Represents a table in the database
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Library> Libraries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Setting up One-to-Many : Author -> Books



        modelBuilder.Entity<Book>(y => {

            y.ToTable("book")
            .Property(b => b.AuthorId).HasColumnName("id_author");
            y.HasOne(a => a.Author)
            .WithMany(b => b.Books)
            .HasForeignKey(x => x.AuthorId);


             
        });
            


        modelBuilder.Entity<Book>(x =>
        {
            x.ToTable("book");
            x.Property(b => b.AuthorId).HasColumnName("id_author");
            x.HasMany(a => a.Libraries)
            .WithMany(b => b.Books)
            .UsingEntity("stock");
            x.HasOne(x => x.Author);

        });
        // Setting up Many-to-Many : Library <-> Books
        modelBuilder.Entity<Library>()
            .HasMany(l => l.Books)
            .WithMany(b => b.Libraries)
            .UsingEntity(j => j.ToTable("library_books"));
    }
}