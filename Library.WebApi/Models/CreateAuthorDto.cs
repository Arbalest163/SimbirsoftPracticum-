using AutoMapper;
using Library.Application.Authors.Commands.CreateAuthor;
using Library.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace Library.WebApi.Models
{
    public class CreateAuthorDto : IMapWith<CreateAuthorCommand>
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAuthorDto, CreateAuthorCommand>()
                    .ForMember(aC => aC.FirstName,
                    opt => opt.MapFrom(aDto => aDto.FirstName))
                    .ForMember(aC => aC.LastName,
                    opt => opt.MapFrom(aDto => aDto.LastName))
                    .ForMember(aC => aC.MiddleName,
                    opt => opt.MapFrom(aDto => aDto.MiddleName));
        }
    }
}