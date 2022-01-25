using AutoMapper;
using Library.Application.Books.Commands.CreateBook;
using Library.Application.Common.Mappings;
using Library.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.Models
{
    public class CreateBookDto : IMapWith<CreateBookCommand>
    {
        [Required]
        public string Name { get; set; }
        public Guid GenreId { get; set; }
        public Guid AuthorId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBookDto, CreateBookCommand>()
                    .ForMember(b => b.Name,
                    opt => opt.MapFrom(bookDto => bookDto.Name))
                    .ForMember(b => b.GenreId,
                    opt => opt.MapFrom(bookDto => bookDto.GenreId))
                    .ForMember(b => b.AuthorId,
                    opt => opt.MapFrom(bookDto => bookDto.AuthorId));
        }
    }
}
