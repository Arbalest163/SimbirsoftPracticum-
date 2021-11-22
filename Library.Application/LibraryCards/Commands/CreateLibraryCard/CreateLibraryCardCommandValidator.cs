using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.LibraryCards.Commands.CreateLibraryCard
{
    public class CreateLibraryCardCommandValidator : AbstractValidator<CreateLibraryCardCommand>
    {
        public CreateLibraryCardCommandValidator()
        {
            RuleFor(p => p.PersonId).NotEqual(Guid.Empty);
            RuleFor(b => b.BookId).NotEqual(Guid.Empty);
        }
    }
}
