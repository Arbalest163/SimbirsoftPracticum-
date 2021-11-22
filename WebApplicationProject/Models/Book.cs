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

        public int Id { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public string Genre { get; set; }


    }
}
