using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
{
    private readonly LibraryContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(LibraryContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();  // Set<T> : Generic access to the table
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public T Get(int id)
    {
        return _dbSet.FirstOrDefault(e=>e.Id==id) ;
    }
    
    public T Add(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
        return entity;
    }


    public void Delete(int id)
    {
        var entity = _dbSet.Find(id);
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }
}