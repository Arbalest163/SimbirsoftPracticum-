using System;
using MediatR;

namespace Library.Application.Persons.Commands.UpdatePerson
{
    public class UpdatePersonCommand : IRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
