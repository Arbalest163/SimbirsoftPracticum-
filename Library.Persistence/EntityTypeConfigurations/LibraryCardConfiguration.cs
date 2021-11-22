﻿using Library.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence.EntityTypeConfigurations
{
    public class LibraryCardConfiguration : IEntityTypeConfiguration<LibraryCard>
    {
        public void Configure(EntityTypeBuilder<LibraryCard> builder)
        {
            builder.ToTable("library_card");
            builder.HasKey(l => l.Id);
            builder.HasIndex(l => l.Id).IsUnique();
            builder.HasIndex(l => l.BookId).IsUnique();
            
        }
    }
}
