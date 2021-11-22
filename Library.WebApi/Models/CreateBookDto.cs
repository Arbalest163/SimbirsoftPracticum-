using AutoMapper;
using Library.Application.Books.Commands.CreateBook;
using Library.Application.Common.Mappings;
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
        public string Title { get; set; }
        [Required]
        public List<Guid> GenresId { get; set; }
        [Required]
        public Guid AuthorId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBookDto, CreateBookCommand>()
                    .ForMember(b => b.Title,
                    opt => opt.MapFrom(bookDto => bookDto.Title))
                    .ForMember(b => b.GenresId,
                    opt => opt.MapFrom(bookDto => bookDto.GenresId))
                    .ForMember(b => b.AuthorId,
                    opt => opt.MapFrom(bookDto => bookDto.AuthorId));
        }
    }
}
