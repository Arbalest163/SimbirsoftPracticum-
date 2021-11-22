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

namespace Library.Application.Books.Queries.GetBookById
{
    public class GetBookByIdQueryHandler
    : IRequestHandler<GetBookByIdQuery, BookVm>
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(ILibraryDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<BookVm> Handle(GetBookByIdQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Books
                    .FirstOrDefaultAsync(b =>
                    b.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            return _mapper.Map<BookVm>(entity);
        }
    }
}
