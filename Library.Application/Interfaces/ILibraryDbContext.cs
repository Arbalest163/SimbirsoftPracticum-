using System.Threading;
using System.Threading.Tasks;
using Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Interfaces
{
    public interface ILibraryDbContext
    {
        DbSet<Person> Persons { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<LibraryCard> LibraryCards { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
