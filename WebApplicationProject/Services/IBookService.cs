using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Models;

namespace WebApplicationProject.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        IActionResult Get(int id);
        IActionResult Get(string query);
        IActionResult Create(Book book);
        IActionResult Delete(int id);
        IEnumerable<Book> GetSortedByTitle();
        IEnumerable<Book> GetSortedByAuthorId();
        IEnumerable<Book> GetSortedByGenre();
    }
}
