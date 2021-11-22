using System;
using System.Collections.Generic;

namespace Library.Domain
{
    /// <summary>
    /// 2.2 Сущность из базы данных
    /// </summary>
    public class Genre
    {
        public Genre() => BookGenre = new List<BookGenre>();

        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<BookGenre> BookGenre { get; set; }
    }
}
