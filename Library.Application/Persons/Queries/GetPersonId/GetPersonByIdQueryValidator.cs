using FluentValidation;
using System;

namespace Library.Application.Persons.Queries.GetPersonId
{
    public class GetPersonByIdQueryValidator : AbstractValidator<GetPersonByIdQuery>
    {
        public GetPersonByIdQueryValidator()
        {
            RuleFor(p => p.Id).NotEqual(Guid.Empty);
        }
    }
}
