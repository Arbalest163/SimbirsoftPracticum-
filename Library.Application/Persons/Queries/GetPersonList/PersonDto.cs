using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Domain;
using System;

namespace Library.Application.Persons.Queries.GetPersonList
{
    public class PersonDto : IMapWith<Person>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birthday { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Person, PersonDto>()
                    .ForMember(pDto => pDto.Id,
                    opt => opt.MapFrom(p => p.Id))
                    .ForMember(pDto => pDto.Name,
                    opt => opt.MapFrom(p => p.Name))
                    .ForMember(pDto => pDto.LastName,
                    opt => opt.MapFrom(p => p.LastName))
                    .ForMember(pDto => pDto.MiddleName,
                    opt => opt.MapFrom(p => p.MiddleName))
                    .ForMember(pDto => pDto.Birthday,
                    opt => opt.MapFrom(p => p.Birthday));
        }
    }
}
