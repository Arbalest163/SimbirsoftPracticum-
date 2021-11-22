using Library.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public List<Guid> GenresId { get; set; }
        public Guid AuthorId { get; set; }
    }
}
