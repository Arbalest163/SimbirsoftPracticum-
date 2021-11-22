using AutoMapper;
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

namespace Library.Application.Genres.Queries.GetGenreStatistic
{
    public class GetGenreStatisticQueryHandler
        : IRequestHandler<GetGenreStatisticQuery, GenreStatisticVm>
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGenreStatisticQueryHandler(ILibraryDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GenreStatisticVm> Handle(GetGenreStatisticQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Genres
                    .FirstOrDefaultAsync(g =>
                    g.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Genre), request.Id);
            }

            return _mapper.Map<GenreStatisticVm>(entity);
        }
    }
}
