using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Books.Queries.GetBookList
{
    public class GetBookListAllQuery : IRequest<BookListVm>
    {
        public string sortingParameter { get; set; }
    }
}
