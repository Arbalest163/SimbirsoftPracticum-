using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Interfaces;
using Library.Application.Common.Exceptions;
using Library.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Application.Books.Queries.GetBookList
{
    public class GetBookListAllQueryHandler
        : IRequestHandler<GetBookListAllQuery, BookListVm>
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBookListAllQueryHandler(ILibraryDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<BookListVm> Handle(GetBookListAllQuery request,
            CancellationToken cancellationToken)
        {
            switch (request.sortingParameter?.ToLower())
            {
                case null:
                    var bookAll = await _dbContext.Books
                        .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);
                    return new BookListVm { Books = bookAll };

                case "author":
                    var sortBookAll = await _dbContext.Books
                        .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
                        .OrderBy(a => a.AuthorId)
                        .ToListAsync(cancellationToken);
                    return new BookListVm { Books = sortBookAll };

                default: throw new InvalidSortingParameterException(request.sortingParameter);
            }
        }
    }
}
