using WebApplicationProject.Context;

namespace WebApplicationProject
{
    public class DbInitializer
    {
        public static void Initialize(LibraryDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
