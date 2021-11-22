using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using Library.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Library.Application.Common.Exceptions;
using Library.Domain;

namespace Library.Application.Persons.Queries.GetPersonList
{
    public class GetPersonListQueryHandler
        : IRequestHandler<GetPersonListQuery, PersonListVm>
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPersonListQueryHandler(ILibraryDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<PersonListVm> Handle(GetPersonListQuery request,
            CancellationToken cancellationToken)
        {
            var lowerRequest = request.Query?.ToLower();
            if (lowerRequest != null)
            {
                var personQuery = await _dbContext.Persons
                        .Where(p => p.FirstName.ToLower().Contains(lowerRequest) ||
                                p.LastName.ToLower().Contains(lowerRequest) ||
                                p.MiddleName.ToLower().Contains(lowerRequest))
                        .ProjectTo<PersonDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);
                if (personQuery.Count == 0)
                {
                    throw new NotFoundException(nameof(Person), request.Query);
                }
                return new PersonListVm { Persons = personQuery };
            }
            else
            {
                var personAll = await _dbContext.Persons
                        .ProjectTo<PersonDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);

                return new PersonListVm { Persons = personAll };
            }
        }
    }
}
