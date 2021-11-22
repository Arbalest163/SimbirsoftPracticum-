using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationProject.Models
{
    public class Book
    {
        public Book(int id, string title, int authorId, string genre)
        {
            Id = id;
            Title = title;
            AuthorId = authorId;
            Genre = genre;
        }

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
