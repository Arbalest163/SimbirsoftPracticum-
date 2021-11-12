using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationProject.Models;

namespace WebApplicationProject.ModelsDTO
{
    /// <summary>
    /// 1.2.2 Класс книга ДТО
    /// </summary>
    public class BookDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public string Genre { get; set; }

    }
}
