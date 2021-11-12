using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Models;

namespace WebApplicationProject.StaticList
{
    /// <summary>
    /// 1.2.3 Статичный список книг
    /// </summary>
    public static class BookList
    {
        public static Dictionary<int, Book> BooksList { get; }

        static BookList()
        {
            BooksList = new Dictionary<int, Book>()
            {
                { 1, new Book(1, "Title7", 2, "Genre5") },
                { 2, new Book(2, "Title6", 2, "Genre2") },
                { 3, new Book(3, "Title9", 1, "Genre1") }
            };
        }
    }
}
