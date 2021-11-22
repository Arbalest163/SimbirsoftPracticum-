using System;
using FluentValidation;

namespace Library.Application.Persons.Commands.DeletePerson
{
    public class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommand>
    {
        public DeletePersonCommandValidator()
        {
            RuleFor(deletePersonCommand => 
                deletePersonCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
