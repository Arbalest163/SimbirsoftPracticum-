using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Models;
using WebApplicationProject.StaticList;

namespace WebApplicationProject.Services
{
    public class BookService : IBookService
    {
        private readonly Dictionary<int, Book> _books;

        public BookService()
        {
            _books = BookList.BooksList;
        }

        public IActionResult Create(Book book)
        {
            if (_books.TryGetValue(book.Id, out var _book))
            {
                return new NotFoundObjectResult("Книга с таким ID уже есть.");
            }

            _books.Add(book.Id, book);
            return new OkObjectResult("Книга добавлена.");
        }

        public IActionResult Delete(int id)
        {
            if (!_books.TryGetValue(id, out var book))
            {
                return new NotFoundObjectResult("Книги с таким ID нет.");
            }
            _books.Remove(id);
            return new OkObjectResult("Книга удалена.");
        }

        public IActionResult Get(int id)
        {
            if (!_books.TryGetValue(id, out var book))
            {
                return new OkObjectResult(book);
            }

            return new NotFoundObjectResult("Книги с таким ID нет.");
        }

        public IActionResult Get(string authorId)
        {
            var returnBooks = _books.Values.Where(a => a.AuthorId == Int32.Parse(authorId));

            if (returnBooks.Count() == 0)
            {
                return new NotFoundObjectResult("Книг с таким автором нет.");
            }

            return new OkObjectResult(returnBooks);
        }
        public IEnumerable<Book> GetSortedByTitle()
        {
            return _books.Values.ToList().OrderBy(x => x.Title);
        }


        public IEnumerable<Book> GetAll()
        {
            return _books.Values;
        }

        public IEnumerable<Book> GetSortedByAuthorId()
        {
            return _books.Values.ToList().OrderBy(x => x.AuthorId);
        }

        public IEnumerable<Book> GetSortedByGenre()
        {
            return _books.Values.ToList().OrderBy(x => x.Genre);
        }
    }
}
