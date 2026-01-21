using System.Collections.Generic;

public interface IGenericRepository<T> where T : IEntity
{
    IEnumerable<T> GetAll();
    T Get(int id);
}