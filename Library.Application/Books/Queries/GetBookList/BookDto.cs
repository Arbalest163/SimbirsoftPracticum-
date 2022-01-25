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
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Author> Authors { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookDto>();
        }
    }
}