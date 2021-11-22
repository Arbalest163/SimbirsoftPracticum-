using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Models;

namespace WebApplicationProject.StaticList
{
    /// <summary>
    /// 1.2.3 Статичный список людей
    /// </summary>
    public static class HumanList
    {
        public static Dictionary<int, Human> HumansList { get; }
        static HumanList()
        {
            HumansList = new Dictionary<int, Human>()
            {
                { 1, new Human(1,"Иван", "Гилязов", "Владимирович", new DateTime(1989, 11, 06)) },
                { 2, new Human(2,"Сергей", "Ярушин", "Петрович", new DateTime(1989, 11, 06)) },
                { 3, new Human(3,"Алексей", "Честнов", "Дмитриевич", new DateTime(1989, 11, 06)) }
            };
        }
    }
}
