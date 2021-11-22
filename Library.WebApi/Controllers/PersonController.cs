using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Library.WebApi.Models;
using Library.Application.Persons.Queries.GetPersonList;
using Library.Application.Persons.Queries.GetPersonId;
using Library.Application.Persons.Commands.CreatePerson;
using Library.Application.Persons.Commands.DeletePerson;
using Library.Application.Persons.Commands.UpdatePerson;

namespace Library.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : BaseController
    {
        private readonly IMapper _mapper;

        public PersonController(IMapper mapper) => _mapper = mapper;

        
        [HttpGet("PersonList")]
        public async Task<ActionResult<PersonListVm>> Get(string query = null)
        {
            var returnPersonList = new GetPersonListQuery
            {
                Query = query
            };
            var vm = await Mediator.Send(returnPersonList);
            return Ok(vm);
        }

        [HttpGet("id")]
        public async Task<ActionResult<PersonVm>> GetById(Guid id)
        {
            var query = new GetPersonByIdQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// 7.1.1 Добавление пользователя
        /// </summary>
        /// <param name="createPersonDto"></param>
        /// <returns></returns>
        [HttpPost("CreatePerson")]
        public async Task<ActionResult<Guid>> Create([FromForm] CreatePersonDto createPersonDto)
        {
            var command = _mapper.Map<CreatePersonCommand>(createPersonDto);
            var personId = await Mediator.Send(command);
            return Ok(personId);
        }

        /// <summary>
        /// 7.1.2 Обновление данных пользователя
        /// </summary>
        /// <param name="updatePersonDto"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm] UpdatePersonDto updatePersonDto)
        {
            var command = _mapper.Map<UpdatePersonCommand>(updatePersonDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// 7.1.3 Удаление пользователя по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletePersonCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
