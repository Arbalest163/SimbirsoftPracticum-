using AutoMapper;
using Library.Application.Common.Mappings;
using Library.Domain;
using System;

namespace Library.Application.LibraryCards.Queries.GetLibraryCardById
{
    public class LibraryCardVm : IMapWith<LibraryCard>
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid BookId { get; set; }
        public DateTimeOffset TakeDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<LibraryCard, LibraryCardVm>()
                    .ForMember(lVm => lVm.Id,
                    opt => opt.MapFrom(l => l.Id))
                    .ForMember(lVm => lVm.PersonId,
                    opt => opt.MapFrom(l => l.PersonId))
                    .ForMember(lVm => lVm.BookId,
                    opt => opt.MapFrom(l => l.BookId))
                    .ForMember(lVm => lVm.TakeDate,
                    opt => opt.MapFrom(l => l.TakenDate));
        }
    }
}