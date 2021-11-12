using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Models;

namespace WebApplicationProject.Services
{
    public interface IHumanService
    {
        IEnumerable<Human> GetAll();
        IActionResult Get(int id);
        IActionResult Get(string query);
        IActionResult Create(Human h);
        IActionResult Update(Human h);
        IActionResult Delete(int id);
    }
}
