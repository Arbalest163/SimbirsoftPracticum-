using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain
{
    /// <summary>
    /// 2.2 Сущность из базы данных
    /// </summary>
    public class LibraryCard
    {
        public virtual ICollection<Person> Persons { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public DateTimeOffset TakenDate { get; set; }
    }
}
