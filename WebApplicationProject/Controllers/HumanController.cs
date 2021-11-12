using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Models;
using WebApplicationProject.Services;
using WebApplicationProject.StaticList;


namespace WebApplicationProject.Controllers
{
    /// <summary>
    /// 1.3 Контроллер, отвечающий за человека
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private readonly IHumanService _humanService;

        public HumanController(IHumanService humanService)
        {
            _humanService = humanService;
        }

        /// <summary>
        /// 1.3.1.1 Метод возвращает список всех людей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllHumans()
        {
            return Ok(_humanService.GetAll());
        }

        /// <summary>
        /// 1.3.1 Метод возвращает человека по ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_humanService.Get(id));
        }

        /// <summary>
        /// 1.3.1.3 Метод возвращает список людей, в ФИО которых содержится искомая фраза
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetByQuery(string query)
        {
            return Ok(_humanService.Get(query));
        }

        /// <summary>
        /// 1.3.2 Метод POST, добавляющий нового человека
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add([FromBody] HumanDto humanDto)
        {
            var human = mappingToHuman(humanDto);
            return Ok(_humanService.Create(human));
        }

        [HttpPut]
        public IActionResult Update(HumanDto humanDto)
        {
            var human = mappingToHuman(humanDto);
            return Ok(_humanService.Update(human));
        }

        /// <summary>
        /// 1.3.3 Метод DELETE, удаляющий человека по ID
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(_humanService.Delete(id));
        }

        private Human mappingToHuman(HumanDto humanDto)
        {
            return new Human(humanDto.Id, humanDto.Name, humanDto.LastName, humanDto.Patronimic, humanDto.Birthday);
        }

        private HumanDto mappingToHumanDto(Human human)
        {
            var humanDto = new HumanDto();
            human.Id = humanDto.Id;
            human.Name = humanDto.Name;
            human.LastName = humanDto.LastName;
            human.Patronimic = humanDto.Patronimic;
            human.Birthday = human.Birthday;

            return humanDto;
        }
    }
}
