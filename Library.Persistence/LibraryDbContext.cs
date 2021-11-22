using Microsoft.EntityFrameworkCore;
using Library.Application.Interfaces;
using Library.Domain;
using Library.Persistence.EntityTypeConfigurations;

namespace Library.Persistence
{
    public class LibraryDbContext : DbContext, ILibraryDbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PersonConfiguration());
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new AuthorConfiguration());
            builder.ApplyConfiguration(new LibraryCardConfiguration());
            builder.ApplyConfiguration(new BookGenreConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
