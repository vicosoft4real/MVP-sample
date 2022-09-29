using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Number).HasMaxLength(20);
        builder.Property(x => x.Description).HasMaxLength(200);
        builder.Property(x => x.Price).HasPrecision(2).IsRequired();
        builder.Property(x => x.Active).IsRequired();

    }
}