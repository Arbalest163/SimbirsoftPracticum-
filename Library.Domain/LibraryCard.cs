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
    public class LibraryCard : Entity
    {
        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }
        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }
        public DateTimeOffset TakenDate { get; set; }
    }
}
