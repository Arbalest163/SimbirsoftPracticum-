using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using Library.Application.Interfaces;
using Library.Application.Common.Exceptions;
using Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Persons.Commands.DeletePerson
{
    public class DeletePersonCommandHandler
        :IRequestHandler<DeletePersonCommand>
    {
        private readonly ILibraryDbContext _dbContext;
        public DeletePersonCommandHandler(ILibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Persons.SingleOrDefaultAsync(p=>p.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }

            _dbContext.Persons.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
