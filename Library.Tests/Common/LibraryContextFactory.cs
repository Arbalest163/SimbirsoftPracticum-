using System;
using Microsoft.EntityFrameworkCore;
using Library.Domain;
using Library.Persistence;
using AutoFixture;

namespace Library.Tests.Common
{
    public class LibraryContextFactory
    {
        public static Person PersonOne = new Fixture().Build<Person>().Without(p => p.LibraryCards).Create();

        public static Book BookOne = new Fixture().Build<Book>().Without(b => b.LibraryCards)
                                                                .Without(b => b.BookGenre)
                                                                .Without(b => b.Author)
                                                                .Create();

        public static Author AuthorOne = new Fixture().Build<Author>().Without(a => a.Books).Create();

        public static Genre GenreOne = new Fixture().Build<Genre>().Without(g => g.BookGenre).Create();

        public static LibraryDbContext Create()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;
            var context = new LibraryDbContext(options);
            context.Database.EnsureCreated();

            context.Persons.Add(PersonOne);
            context.Books.Add(BookOne);
            context.Authors.Add(AuthorOne);
            context.Genres.Add(GenreOne);

            context.SaveChanges();
            return context;
        }

        public static void Destroy(LibraryDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
