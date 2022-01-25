using System;
using System.Collections.Generic;

namespace Library.Domain
{
    /// <summary>
    /// 2.2 Сущность из базы данных
    /// </summary>
    public class Person : Human
    {
        public DateTime Birthday { get; set; }
        public virtual ICollection<LibraryCard> LibraryCards { get; set; }
    }
}
