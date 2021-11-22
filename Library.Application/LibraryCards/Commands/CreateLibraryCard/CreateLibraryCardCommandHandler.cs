using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.LibraryCards.Commands.CreateLibraryCard
{
    public class CreateLibraryCardCommandHandler
        : IRequestHandler<CreateLibraryCardCommand, Guid>
    {
        private readonly ILibraryDbContext _dbContext;
        public CreateLibraryCardCommandHandler(ILibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreateLibraryCardCommand request, CancellationToken cancellationToken)
        {
            var libraryCard = new LibraryCard
            {
                Id = Guid.NewGuid(),
                PersonId = request.PersonId,
                BookId = request.BookId,
                TakenDate = DateTimeOffset.UtcNow
            };

            await _dbContext.LibraryCards.AddAsync(libraryCard, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return libraryCard.Id;
        }
    }
}
