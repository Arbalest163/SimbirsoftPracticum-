using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProject.Models
{
    /// <summary>
    /// 2.1.1 Класс-агрегатор
    /// </summary>
    public class LibraryCard
    {
       [Key]
        public int Id { get; set; }
        public DateTimeOffset DateTaken { get; private set; }

        [Required]
        public int BookId { get; set; }
        [Required]
        public int HumanId{ get; set; }

        public void SetDate()
        {
            DateTaken = DateTimeOffset.Now;
        }
        
    }
}
