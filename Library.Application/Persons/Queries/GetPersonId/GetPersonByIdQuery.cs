using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Library.Application.Persons.Queries.GetPersonId
{
    public class GetPersonByIdQuery : IRequest<PersonVm>
    {
        public Guid Id { get; set; }
    }
}
