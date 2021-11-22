using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Application.Persons.Commands.UpdatePerson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.Models
{
    public class UpdatePersonDto : IMapWith<UpdatePersonCommand>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePersonDto, UpdatePersonCommand>()
                    .ForMember(personCommand => personCommand.FirstName,
                    opt => opt.MapFrom(personDto => personDto.FirstName))
                    .ForMember(personCommand => personCommand.LastName,
                    opt => opt.MapFrom(personDto => personDto.LastName))
                    .ForMember(personCommand => personCommand.MiddleName,
                    opt => opt.MapFrom(personDto => personDto.MiddleName))
                    .ForMember(personCommand => personCommand.Birthday,
                    opt => opt.MapFrom(personDto => personDto.Birthday));
        }
    }
}
