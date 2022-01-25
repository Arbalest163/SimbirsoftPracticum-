using Library.Application.Common.Exceptions;
using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandHandler
        : IRequestHandler<DeleteAuthorCommand>
    {
        private readonly ILibraryDbContext _dbContext;
        public DeleteAuthorCommandHandler(ILibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Authors.Include(b=>b.Books).FirstOrDefaultAsync(a=>a.Id ==  request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Author), request.Id);
            }
            if (entity.Books.Count > 0)
            {
                throw new NotDeletedException(nameof(Author));
            }

            _dbContext.Authors.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
