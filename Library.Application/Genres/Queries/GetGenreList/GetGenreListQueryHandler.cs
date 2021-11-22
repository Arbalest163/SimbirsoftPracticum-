using AutoMapper;
using AutoMapper.QueryableExtensions;
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

namespace Library.Application.Genres.Queries.GetGenryList
{
    public class GetGenreListQueryHandler
     : IRequestHandler<GetGenreListQuery, GenreListVm>
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGenreListQueryHandler(ILibraryDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<GenreListVm> Handle(GetGenreListQuery request,
            CancellationToken cancellationToken)
        {
            var lowerRequest = request.Query?.ToLower();
            if (lowerRequest != null)
            {
                var genreQuery = await _dbContext.Genres
                        .Where(g => g.Name.ToLower().Contains(lowerRequest))
                        .ProjectTo<GenreDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);
                if (genreQuery.Count == 0)
                {
                    throw new NotFoundException(nameof(Genre), request.Query);
                }
                return new GenreListVm { Genres = genreQuery };
            }
            else
            {
                var genreAll = await _dbContext.Genres
                        .ProjectTo<GenreDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);

                return new GenreListVm { Genres = genreAll };
            }
        }
    }
}
