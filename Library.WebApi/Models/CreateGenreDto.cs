using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Application.Genres.Commands.CreateGenre;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.Models
{
    public class CreateGenreDto : IMapWith<CreateGenreCommand>
    {
        [Required]
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateGenreDto, CreateGenreCommand>()
                    .ForMember(gC => gC.Name,
                    opt => opt.MapFrom(gDto => gDto.Name));
        }
    }
}
