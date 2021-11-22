using Library.Application.Common.Mappings;
using Library.Domain;
using AutoMapper;
using System;

namespace Library.Application.Persons.Queries.GetPersonId
{
    public class PersonVm : IMapWith<Person>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birthday { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Person, PersonVm>()
                    .ForMember(pVm => pVm.Id,
                    opt => opt.MapFrom(p => p.Id))
                    .ForMember(pVm => pVm.FirstName,
                    opt => opt.MapFrom(p => p.FirstName))
                    .ForMember(pVm => pVm.LastName,
                    opt => opt.MapFrom(p => p.LastName))
                    .ForMember(pVm => pVm.MiddleName,
                    opt => opt.MapFrom(p => p.MiddleName))
                    .ForMember(pVm => pVm.Birthday,
                    opt => opt.MapFrom(p => p.Birthday));
        }
    }
}
