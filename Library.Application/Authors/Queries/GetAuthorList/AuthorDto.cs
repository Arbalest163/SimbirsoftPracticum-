using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Domain;
using System;

namespace Library.Application.Authors.Queries.GetAuthorList
{
    public class AuthorDto : IMapWith<Author>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorDto>()
                    .ForMember(pDto => pDto.Id,
                    opt => opt.MapFrom(p => p.Id))
                    .ForMember(pDto => pDto.FirstName,
                    opt => opt.MapFrom(p => p.FirstName))
                    .ForMember(pDto => pDto.LastName,
                    opt => opt.MapFrom(p => p.LastName))
                    .ForMember(pDto => pDto.MiddleName,
                    opt => opt.MapFrom(p => p.MiddleName));
        }
    }
}