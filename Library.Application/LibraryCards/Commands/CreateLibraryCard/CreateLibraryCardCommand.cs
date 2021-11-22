using MediatR;
using System;

namespace Library.Application.LibraryCards.Commands.CreateLibraryCard
{
    public class CreateLibraryCardCommand : IRequest<Guid>
    {
        public Guid PersonId { get; set; }
        public Guid BookId { get; set; }
    }
}
