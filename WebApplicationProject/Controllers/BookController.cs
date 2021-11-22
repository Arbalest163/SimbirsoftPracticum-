using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Models;
using WebApplicationProject.ModelsDTO;
using WebApplicationProject.Services;

namespace WebApplicationProject.Controllers
{
    /// <summary>
    /// 1.3 Контроллер, отвечающий за книгу
    /// </summary>
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// 1.4.1.1 Метод возвращает список всех книг
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(_bookService.GetAll());
        }

        /// <summary>
        /// 1.4.1 Метод возвращает книгу по ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_bookService.Get(id));
        }

        /// <summary>
        /// 1.4.1.2 Метод возвращает список книг, с фильтрацией по AuthorID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetByAuthorId(string authorId)
        {
            return Ok(_bookService.Get(authorId));
        }

        /// <summary>
        /// 2.2.2 Запрос на получение списка книг, сортированных по названию
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetSortedByTitle()
        {
            return Ok(_bookService.GetSortedByTitle());
        }

        /// <summary>
        /// 2.2.2 Запрос на получение списка книг, сортированных по автору
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetSortedByAuthorId()
        {
            return Ok(_bookService.GetSortedByAuthorId());
        }

        /// <summary>
        /// 2.2.2 Запрос на получение списка книг, сортированных по жанру
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetSortedByGenre()
        {
            return Ok(_bookService.GetSortedByGenre());
        }

        /// <summary>
        /// 1.4.2 Метод POST, добавляющий новую книгу
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add([FromBody] BookDto bookDto)
        {
            var book = mappingToHuman(bookDto);
            return Ok(_bookService.Create(book));
        }

        /// <summary>
        /// 1.4.3 Метод DELETE, удаляющий книгу по ID
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(_bookService.Delete(id));
        }

        private Book mappingToHuman(BookDto bookDto)
        {
            return new Book(bookDto.Id, bookDto.Title, bookDto.AuthorId, bookDto.Genre);
        }

        private BookDto mappingToHumanDto(Book book)
        {
            var bookDto = new BookDto();
            bookDto.Id = book.Id;
            bookDto.Title = book.Title;
            bookDto.AuthorId = book.AuthorId;
            bookDto.Genre = book.Genre;

            return bookDto;
        }
    }
}
