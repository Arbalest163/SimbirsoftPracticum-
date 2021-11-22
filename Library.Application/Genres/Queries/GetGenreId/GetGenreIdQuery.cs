using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Genres.Queries.GetGenreId
{
    public class GetGenreIdQuery : IRequest<GenreVm>
    {
        public Guid Id { get; set; }
    }
}
