using AutoMapper;
using Library.Application.Books.Commands.CreateBook;
using Library.Application.Books.Commands.DeleteBook;
using Library.Application.Books.Queries.GetBookById;
using Library.Application.Books.Queries.GetBookList;
using Library.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BookController : BaseController
    {
        private readonly IMapper _mapper;

        public BookController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Получение всех книг
        /// </summary>
        /// <param name="sortingParameter"></param>
        /// <returns></returns>
        [HttpGet("AllBooks")]
        public async Task<ActionResult<BookListVm>> GetAll(string sortingParameter = null)
        {
            var returnQuery = new GetBookListAllQuery
            {
                sortingParameter = sortingParameter
            };

            var vm = await Mediator.Send(returnQuery);
            return Ok(vm);
        }

        [HttpGet("id")]
        public async Task<ActionResult<BookVm>> GetById(Guid id)
        {
            var query = new GetBookByIdQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// 7.2.1 Добавление книги
        /// </summary>
        /// <param name="createBookDto"></param>
        /// <returns></returns>
        [HttpPost("CreateBook")]
        public async Task<ActionResult<Guid>> Create([FromForm] CreateBookDto createBookDto)
        {
            var command = _mapper.Map<CreateBookCommand>(createBookDto);

            var bookId = await Mediator.Send(command);
            return Ok(bookId);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteBookCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
