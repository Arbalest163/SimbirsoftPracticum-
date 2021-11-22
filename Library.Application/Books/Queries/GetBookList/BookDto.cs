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
        public string Title { get; set; }
        public List<BookGenre> BookGenre { get; set; }
        public Guid AuthorId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookDto>()
                    .ForMember(bVm => bVm.Id,
                    opt => opt.MapFrom(b => b.Id))
                    .ForMember(bVm => bVm.Title,
                    opt => opt.MapFrom(b => b.Title))
                    .ForMember(bVm => bVm.BookGenre,
                    opt => opt.MapFrom(b => b.BookGenre))
                    .ForMember(bVm => bVm.AuthorId,
                    opt => opt.MapFrom(b => b.AuthorId));
        }
    }
}