using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Authors.Queries.GetAuthorList
{
    public class GetAuthorListQueryHandler
    : IRequestHandler<GetAuthorListQuery, AuthorListVm>
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAuthorListQueryHandler(ILibraryDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<AuthorListVm> Handle(GetAuthorListQuery request,
            CancellationToken cancellationToken)
        {

            var authorAll = await _dbContext.Authors
                    .ProjectTo<AuthorDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return new AuthorListVm { Authors = authorAll };

        }
    }
}
