using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Models;
using WebApplicationProject.Services;



namespace WebApplicationProject.Controllers
{
    /// <summary>
    /// 2.1.2 Контроллер, отвечающий за взятие человеком книги
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryCardController : ControllerBase
    {
        private readonly ILibraryCardService _libraryCardService;

        public LibraryCardController(ILibraryCardService libraryCardService)
        {
            _libraryCardService = libraryCardService;
        }

        [HttpGet]
        public IActionResult GetAllLibraryCards()
        {
            return Ok(_libraryCardService.GetAll());
        }

        [HttpPost]
        public IActionResult Add(LibraryCard lb)
        {
            return Ok(_libraryCardService.Create(lb));
        }
    }
}
