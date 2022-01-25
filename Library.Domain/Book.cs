using System;
using System.Collections.Generic;

namespace Library.Domain
{
    /// <summary>
    /// 2.2 Сущность из базы данных
    /// </summary>
    public class Book : NamedEntity
    {
        public Guid GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<LibraryCard> LibraryCards { get; set; }
        public Guid AuthorId { get; set; }
        public virtual Author Author { get; set; }

    }
}
