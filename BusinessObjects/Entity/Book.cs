using System.Collections.Generic;

namespace BusinessObjects.Entity
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Pages { get; set; }
        public TypeBook Type { get; set; }
        public int Rate { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
