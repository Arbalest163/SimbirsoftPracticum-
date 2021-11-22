using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Domain;
using System;

namespace Library.Application.Genres.Queries.GetGenryList
{
    public class GenreDto : IMapWith<Genre>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Genre, GenreDto>()
                    .ForMember(gDto => gDto.Id,
                    opt => opt.MapFrom(g => g.Id))
                    .ForMember(gDto => gDto.Name,
                    opt => opt.MapFrom(g => g.Name));
        }
    }
}