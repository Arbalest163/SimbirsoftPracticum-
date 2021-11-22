using AutoMapper;
using Library.Application.Authors.Commands.CreateAuthor;
using Library.Application.Authors.Commands.DeleteAuthor;
using Library.Application.Authors.Queries.GetAuthorList;
using Library.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : BaseController
    {
        private readonly IMapper _mapper;

        public AuthorController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// 7.3.1 Получение списка всех авторов
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllAuthor")]
        public async Task<ActionResult<AuthorListVm>> Get()
        {
            var returnAll = new GetAuthorListQuery();
            var vm = await Mediator.Send(returnAll);
            return Ok(vm);
        }
        /// <summary>
        /// 7.3.3 Добавление автора
        /// </summary>
        /// <param name="createAuthorDto"></param>
        /// <returns></returns>
        [HttpPost("CreateAuthor")]
        public async Task<ActionResult<Guid>> Create([FromForm] CreateAuthorDto createAuthorDto)
        {
            var command = _mapper.Map<CreateAuthorCommand>(createAuthorDto);

            var authorId = await Mediator.Send(command);
            return Ok(authorId);
        }
        
        /// <summary>
        /// 7.3.4 Удаление автора
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteAuthorCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
