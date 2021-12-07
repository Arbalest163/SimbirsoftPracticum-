using AutoMapper;
using Library.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Library.Domain;

namespace Library.Application.Genres.Commands.CreateGenre
{
    public class CreateGenreCommandHandler
        : IRequestHandler<CreateGenreCommand, Guid>
    {
        private readonly ILibraryDbContext _dbContext;

        public CreateGenreCommandHandler(ILibraryDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre()
            {
                Name = request.Name
            };
            await _dbContext.Genres.AddAsync(genre, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return genre.Id;
        }
    }
}
