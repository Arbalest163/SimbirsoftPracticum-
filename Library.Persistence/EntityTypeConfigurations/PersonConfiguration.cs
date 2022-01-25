using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.EntityTypeConfigurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("persons");
            builder.Property(n => n.Name).IsRequired();
            builder.Property(n => n.LastName).IsRequired();
            builder.Property(n => n.Birthday).IsRequired();
        }

    }
}
