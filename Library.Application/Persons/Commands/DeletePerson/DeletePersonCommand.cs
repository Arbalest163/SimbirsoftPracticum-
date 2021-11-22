using System;
using MediatR;

namespace Library.Application.Persons.Commands.DeletePerson
{
    public class DeletePersonCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
