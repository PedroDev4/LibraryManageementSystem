using LibraryManagement.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Infrastructure.Config
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Number).IsRequired();
            builder.Property(a => a.Street).IsRequired().HasColumnType("varchar(120)").HasMaxLength(120);
            builder.Property(a => a.State).IsRequired().HasColumnType("varchar(2)").HasMaxLength(2);
            builder.Property(a => a.Zipcode).IsRequired().HasColumnType("varchar(9)").HasMaxLength(9);
            builder.Property(a => a.Country).IsRequired().HasColumnType("varchar(40)").HasMaxLength(40);
            builder.Property(a => a.City).IsRequired().HasColumnType("varchar(40)").HasMaxLength(40);

        }
    }
}