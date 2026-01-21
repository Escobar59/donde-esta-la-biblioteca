using System.Collections.Generic;

namespace BusinessObjects.Entity
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
