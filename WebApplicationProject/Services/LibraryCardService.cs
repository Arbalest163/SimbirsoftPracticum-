using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Models;
using WebApplicationProject.StaticList;

namespace WebApplicationProject.Services
{
    public class LibraryCardService : ILibraryCardService
    {
        private readonly Dictionary<int, LibraryCard> _libraryCards;

        public LibraryCardService()
        {
            _libraryCards = LibraryCardList.LibraryCards;
        }
        public IActionResult Create(LibraryCard obj)
        {
            obj.SetDate();
            _libraryCards.Add(obj.Id, obj);
            return new OkObjectResult("Карточка добавлена");
        }

        public IEnumerable<LibraryCard> GetAll()
        {
            return _libraryCards.Values;
        }

    }
}
