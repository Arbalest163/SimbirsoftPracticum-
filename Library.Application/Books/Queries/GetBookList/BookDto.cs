using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Domain;
using System;
using System.Collections.Generic;

namespace Library.Application.Books.Queries.GetBookList
{
    public class BookDto : IMapWith<Book>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string GenreName { get; set; }
        public string AuthorFullName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookDto>()
                .ForMember(g => g.GenreName, opt => opt.MapFrom(g => g.Genre.Name))
                .ForMember(a=>a.AuthorFullName, opt => opt.MapFrom(g=> $"{g.Author.Name} {g.Author.LastName} {g.Author.MiddleName}" ));
        }

    }
}