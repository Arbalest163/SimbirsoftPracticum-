using System;
using FluentValidation;

namespace Library.Application.Persons.Commands.UpdatePerson
{
    public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidator()
        {
            RuleFor(updatePersonCommand =>
                  updatePersonCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updatePersonCommand =>
                  updatePersonCommand.Name).NotEmpty();
            RuleFor(updatePersonCommand =>
                updatePersonCommand.LastName).NotEmpty();
            RuleFor(updatePersonCommand =>
                updatePersonCommand.Birthday).NotEmpty();

        }
    }
}
