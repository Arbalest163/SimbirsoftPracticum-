using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.EntityTypeConfigurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("genre");
            builder.HasKey(g => g.Id);
            builder.HasIndex(g => g.Id).IsUnique();
            builder.HasIndex(g => g.Name).IsUnique();
        }
    }
}
