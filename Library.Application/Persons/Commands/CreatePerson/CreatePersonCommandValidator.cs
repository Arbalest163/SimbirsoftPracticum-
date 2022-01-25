using FluentValidation;

namespace Library.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(createPersonCommand =>
                createPersonCommand.Name).NotEmpty();
            RuleFor(createPersonCommand =>
                createPersonCommand.LastName).NotEmpty();
            RuleFor(createPersonCommand =>
                createPersonCommand.Birthday).NotEmpty();
        }
    }
}
