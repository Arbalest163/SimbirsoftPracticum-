using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Common.Exceptions
{
    public class NotDeletedException : Exception
    {
        public NotDeletedException(string name)
           : base($"Сущность \"{name}\" нельзя удалить, так у него есть книги.") { }
    }
}
