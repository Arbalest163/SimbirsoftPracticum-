using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.LibraryCards.Queries.GetLibraryCardById
{
    public class GetLibraryCardByIdQuery : IRequest<LibraryCardVm>
    {
        public Guid Id { get; set; }
    }
}
