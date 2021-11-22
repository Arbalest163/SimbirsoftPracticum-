using System;
using System.Collections.Generic;

namespace Library.Domain
{
    /// <summary>
    /// 2.2 Сущность из базы данных
    /// </summary>
    public class Author : Human
    {
        public Author() => Books = new List<Book>();
        
        public ICollection<Book> Books { get; set; }
    }
}
