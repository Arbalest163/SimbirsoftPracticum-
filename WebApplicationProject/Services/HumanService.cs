using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Models;
using WebApplicationProject.StaticList;

namespace WebApplicationProject.Services
{
    public class HumanService : IHumanService
    {
        private readonly Dictionary<int, Human> _humans;

        public HumanService()
        {
            _humans = HumanList.HumansList;
        }
        public IActionResult Create(Human human)
        {
            if (_humans.TryGetValue(human.Id, out var existingHuman))
            {
                return new NotFoundObjectResult("Человека с таким ID уже есть.");
            }
            _humans.Add(human.Id, human);
            return new OkObjectResult("Человек добавлен");

        }

        public IActionResult Delete(int id)
        {
            if (!_humans.TryGetValue(id, out var human))
            {
                return new NotFoundObjectResult("Человека с таким ID нет.");
            }

            _humans.Remove(id);
            return new OkObjectResult("Человек удалён");
        }

        public IActionResult Get(int id)
        {
            if (_humans.TryGetValue(id, out var human))
            {
                return new OkObjectResult(human);
            }

            return new NotFoundObjectResult("Человека с таким ID нет.");
        }

        public IActionResult Get(string query)
        {
            var returnHumans = _humans.Values.Where(h => h.Name.ToLower().Contains(query.ToLower()) ||
                                             h.LastName.ToLower().Contains(query.ToLower()) ||
                                             h.Patronimic.ToLower().Contains(query.ToLower()));
            if (returnHumans.Count() < 1)
            {
                return new NotFoundObjectResult("Людей не найдено.");
            }

            return new OkObjectResult(returnHumans);

        }

        public IEnumerable<Human> GetAll()
        {
            return _humans.Values;
        }

        public IActionResult Update(Human human)
        {
            if (!_humans.TryGetValue(human.Id, out var existingHuman))
            {
                return new NotFoundObjectResult("Человека с таким ID нет.");
            }

            _humans[human.Id] = human;
            return new OkObjectResult("Данные обновлены");
        }
    }
}
