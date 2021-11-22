using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Models;

namespace WebApplicationProject.StaticList
{
    /// <summary>
    /// 2.1.3 Класс для хранения LibraryCards
    /// </summary>
    public static class LibraryCardList
    {
        public static Dictionary<int, LibraryCard> LibraryCards { get; }

        static LibraryCardList()
        {
            LibraryCards = new();
        }
    }
}
