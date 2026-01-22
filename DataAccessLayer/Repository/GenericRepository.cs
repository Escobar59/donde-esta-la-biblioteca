using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
{
    private readonly LibraryContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(LibraryContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();  // Set<T> : Accès générique à la table
    }

    public IEnumerable<T> GetAll()
    {
        var query = _dbSet.AsQueryable();
        if (typeof(T) == typeof(Book))
        {
            query = query.Include("Author");
        }
        else if (typeof(T) == typeof(Library))
        {
            query = query.Include("Books.Author");
        }
        return query.ToList();
    }

    public T Get(int id)
    {
        var query = _dbSet.AsQueryable();
        if (typeof(T) == typeof(Book))
        {
            query = query.Include("Author");
        }
        else if (typeof(T) == typeof(Library))
        {
            query = query.Include("Books.Author");
        }
        return query.FirstOrDefault(e => e.Id == id);
    }
    
    public T Add(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
        return entity;
    }
}