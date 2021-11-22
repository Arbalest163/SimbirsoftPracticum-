using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.LibraryCards.Commands.CreateLibraryCard;
using System.ComponentModel.DataAnnotations;

namespace Library.WebApi.Models
{
    public class CreateLibraryCardDto : IMapWith<CreateLibraryCardCommand>
    {
        [Required]
        public Guid PersonId { get; set; }
        [Required]
        public Guid BookId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateLibraryCardDto, CreateLibraryCardCommand>()
                        .ForMember(lC => lC.PersonId,
                        opt => opt.MapFrom(lDto => lDto.PersonId))
                        .ForMember(lC => lC.BookId,
                        opt => opt.MapFrom(lDto => lDto.BookId));
        }
    }
}
