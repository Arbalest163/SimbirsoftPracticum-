using System;
using System.Threading;
using System.Threading.Tasks;
using Library.Domain;
using Library.Application.Interfaces;
using MediatR;


namespace Library.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandHandler
        :IRequestHandler<CreatePersonCommand, Guid>
    {
        private readonly ILibraryDbContext _dbContext;
        public CreatePersonCommandHandler(ILibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                Birthday = request.Birthday
            };

            await _dbContext.Persons.AddAsync(person, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return person.Id;
        }
    }
}
