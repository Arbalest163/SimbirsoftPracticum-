using Library.Application.Interfaces;
using Library.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler
        : IRequestHandler<CreateAuthorCommand, Guid>
    {
        private readonly ILibraryDbContext _dbContext;

        public CreateAuthorCommandHandler(ILibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Name = request.Name,
                LastName = request.LastName,
                MiddleName = request.MiddleName
            };

            await _dbContext.Authors.AddAsync(author, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return author.Id;
        }
    }
}
