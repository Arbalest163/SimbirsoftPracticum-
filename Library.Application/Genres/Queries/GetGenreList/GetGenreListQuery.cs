using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Genres.Queries.GetGenryList
{
    public class GetGenreListQuery : IRequest<GenreListVm>
    {
        public string Query { get; set; }
    }
}
