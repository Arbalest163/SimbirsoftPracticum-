using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Models;

namespace WebApplicationProject.Services
{
    public interface ILibraryCardService
    {
        IEnumerable<LibraryCard> GetAll();
        IActionResult Create(LibraryCard lb);
        
    }
}
