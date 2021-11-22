using System;
using System.Collections.Generic;

namespace Library.Domain
{
    /// <summary>
    /// 2.2 Сущность из базы данных
    /// </summary>
    public class Person : Human
    {
        public Person() => LibraryCards = new List<LibraryCard>();
        
        public DateTime Birthday { get; set; }
        public ICollection<LibraryCard> LibraryCards { get; set; }
    }
}
