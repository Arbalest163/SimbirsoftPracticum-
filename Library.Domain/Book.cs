using System;
using System.Collections.Generic;

namespace Library.Domain
{
    /// <summary>
    /// 2.2 Сущность из базы данных
    /// </summary>
    public class Book
    {
        public Book()
        {
            BookGenre = new List<BookGenre>();
            LibraryCards = new List<LibraryCard>();
        }
        
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<BookGenre> BookGenre { get; set; }
        public ICollection<LibraryCard> LibraryCards { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }

    }
}
