using System;
using MediatR;

namespace Library.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
