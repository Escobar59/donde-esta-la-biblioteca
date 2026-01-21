using System.Collections.Generic;

// Conservée pour compatibilité : IBookRepository étend l'interface générique
public interface IBookRepository : IGenericRepository<Book>
{
}