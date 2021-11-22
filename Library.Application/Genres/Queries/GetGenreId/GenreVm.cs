using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Genres.Queries.GetGenreId
{
    public class GenreVm : IMapWith<Genre>
    {
        public Guid Id { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Genre, GenreVm>()
                    .ForMember(gVm => gVm.Id,
                    opt => opt.MapFrom(g => g.Id));
        }
    }
}
