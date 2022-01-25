using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Library.Application.Interfaces;
using Library.Application.Persons.Commands.CreatePerson;
using Library.Domain;
using MediatR;

namespace Library.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler
        : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly ILibraryDbContext _dbContext;
        public CreateBookCommandHandler(ILibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Genres = request.Genres,
                Authors = request.Authors
            };


            await _dbContext.Books.AddAsync(book, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return book.Id;
        }
    }
}
