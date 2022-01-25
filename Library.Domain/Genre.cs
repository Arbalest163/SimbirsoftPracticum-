using System;
using System.Collections.Generic;

namespace Library.Domain
{
    /// <summary>
    /// 2.2 Сущность из базы данных
    /// </summary>
    public class Genre : NamedEntity
    {
        public virtual ICollection<Book> Books { get; set; }
    }
}
