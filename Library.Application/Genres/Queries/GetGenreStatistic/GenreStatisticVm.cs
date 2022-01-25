using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Domain;
using System.Collections.Generic;

namespace Library.Application.Genres.Queries.GetGenreStatistic
{
    public class GenreStatisticVm : IMapWith<Genre>
    {
        public string Name { get; set; }
        public int CountBook { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Genre, GenreStatisticVm>()
                .ForMember(gVm => gVm.Name,
                    opt => opt.MapFrom(g => g.Name))
                .ForMember(gVm => gVm.CountBook,
                    opt => opt.MapFrom(g => g.Books.Count));
        }
    }
}