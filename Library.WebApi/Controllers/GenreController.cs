using AutoMapper;
using Library.Application.Genres.Commands.CreateGenre;
using Library.Application.Genres.Queries.GetGenreStatistic;
using Library.Application.Genres.Queries.GetGenryList;
using Library.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.Controllers
{
    /// <summary>
    /// 2.7.4 Контроллер жанры
    /// </summary>
    [Route("api/[controller]")]
    public class GenreController : BaseController
    {
        private readonly IMapper _mapper;

        public GenreController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// 7.4.1 Просмотр всех жанров
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Список жанров, в названии которых есть искомая фраза.
        /// По умолчанию возвращает список всех жанров</returns>
        [HttpGet("GenreList")]
        public async Task<ActionResult<GenreListVm>> Get(string query = null)
        {
            var returnGenreList = new GetGenreListQuery
            {
                Query = query
            };
            var vm = await Mediator.Send(returnGenreList);
            return Ok(vm);
        }

        /// <summary>
        /// 7.4.3 Вывод статистики жанра по количеству книг
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Название жанра - количество книг</returns>
        [HttpGet("GenreStatistic")]
        public async Task<ActionResult<GenreListVm>> Get(Guid id)
        {
            var GenreStatistic = new GetGenreStatisticQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(GenreStatistic);
            return Ok(vm);
        }

        /// <summary>
        /// 7.4.2 Добавление нового жанра
        /// </summary>
        /// <param name="createGenreDto"></param>
        /// <returns>ID нового жанра</returns>
        [HttpPost("CreateGenre")]
        public async Task<ActionResult<Guid>> Create([FromForm] CreateGenreDto createGenreDto)
        {
            var command = _mapper.Map<CreateGenreCommand>(createGenreDto);

            var genreId = await Mediator.Send(command);
            return Ok(genreId);
        }
    }
}
