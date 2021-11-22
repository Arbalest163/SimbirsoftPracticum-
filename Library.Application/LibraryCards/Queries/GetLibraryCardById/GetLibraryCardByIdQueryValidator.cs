using System;
using FluentValidation;

namespace Library.Application.LibraryCards.Queries.GetLibraryCardById
{
    public class GetLibraryCardByIdQueryValidator : AbstractValidator<GetLibraryCardByIdQuery>
    {
        public GetLibraryCardByIdQueryValidator()
        {
            RuleFor(l => l.Id).NotEqual(Guid.Empty);
        }
    }
}
