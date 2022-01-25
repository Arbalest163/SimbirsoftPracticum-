using System.Threading.Tasks;
using MediatR;
using Library.Application.Interfaces;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Library.Application.Common.Exceptions;
using Library.Domain;

namespace Library.Application.Persons.Commands.UpdatePerson
{
    public class UpdatePersonCommandHandler
        : IRequestHandler<UpdatePersonCommand>
    {
        private readonly ILibraryDbContext _dbContext;
        public UpdatePersonCommandHandler(ILibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Persons.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }

            entity.Name = request.Name;
            entity.LastName = request.LastName;
            entity.MiddleName = request.MiddleName;
            entity.Birthday = request.Birthday;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
