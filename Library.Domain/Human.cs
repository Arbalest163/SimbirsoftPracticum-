using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain
{
    /// <summary>
    /// Базовый класс для сущностей с ФИО
    /// </summary>
    public abstract class Human : NamedEntity
    {
       
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}
