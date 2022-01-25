using System;
using System.Collections.Generic;

namespace Library.Domain
{
    /// <summary>
    /// 2.2 Сущность из базы данных
    /// </summary>
    public class Book : NamedEntity
    {
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<LibraryCard> LibraryCards { get; set; }
        public virtual ICollection<Author> Authors { get; set; }

    }
}
