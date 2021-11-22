using System.Threading.Tasks;
using System.Threading;
using MediatR;
using Library.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Library.Application.Common.Exceptions;
using Library.Domain;

namespace Library.Application.Persons.Queries.GetPersonId
{
    public class GetPersonByIdQueryHandler
        :IRequestHandler<GetPersonByIdQuery, PersonVm>
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPersonByIdQueryHandler(ILibraryDbContext dbContext, 
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<PersonVm> Handle(GetPersonByIdQuery request, 
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Persons
                    .FirstOrDefaultAsync(p =>
                    p.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }

            return _mapper.Map<PersonVm>(entity);
        }
    }
}
