using LibraryManagement.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Infrastructure.Config
{
    class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(book => book.Id);
            builder.Property(book => book.Title).IsRequired().HasColumnType("varchar(30)").HasMaxLength(30);
            builder.Property(book => book.Theme).IsRequired().HasColumnType("varchar(15)").HasMaxLength(15);
            builder.Property(book => book.Published).HasColumnType("Datetime");
            builder.Property(book => book.isAvailable).HasColumnType("bit").IsRequired();
        }
    }
}
