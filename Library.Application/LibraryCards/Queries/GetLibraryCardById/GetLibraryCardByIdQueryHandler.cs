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

namespace Library.Application.LibraryCards.Queries.GetLibraryCardById
{
    public class GetLibraryCardByIdQueryHandler
        : IRequestHandler<GetLibraryCardByIdQuery, LibraryCardVm>
    {
        private readonly ILibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetLibraryCardByIdQueryHandler(ILibraryDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<LibraryCardVm> Handle(GetLibraryCardByIdQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.LibraryCards
                    .FirstOrDefaultAsync(l =>
                    l.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(LibraryCard), request.Id);
            }

            return _mapper.Map<LibraryCardVm>(entity);
        }
    }
}
