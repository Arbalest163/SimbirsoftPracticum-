using AutoMapper;
using Library.Application.LibraryCards.Commands.CreateLibraryCard;
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
    public class LibraryCardController : BaseController
    {
        private readonly IMapper _mapper;

        public LibraryCardController(IMapper mapper) => _mapper = mapper;

        [HttpPost("TakeBook")]
        public async Task<ActionResult<Guid>> CreateLibraryCard([FromForm] CreateLibraryCardDto createLibraryCardDto)
        {
            var command = _mapper.Map<CreateLibraryCardCommand>(createLibraryCardDto);
            var LibraryCardId = await Mediator.Send(command);
            return Ok(LibraryCardId);
        }
    }
}
