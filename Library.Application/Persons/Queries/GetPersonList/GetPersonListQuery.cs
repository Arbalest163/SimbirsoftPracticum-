using System;
using MediatR;

namespace Library.Application.Persons.Queries.GetPersonList
{
    public class GetPersonListQuery : IRequest<PersonListVm>
    {
        public string Query { get; set; }
    }
}
