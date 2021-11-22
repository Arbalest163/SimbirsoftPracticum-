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
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public DateTimeOffset TakenDate { get; set; }
    }
}
