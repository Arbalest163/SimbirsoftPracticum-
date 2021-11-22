using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Books.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<BookVm>
    {
        public Guid Id { get; set; }
    }
}
