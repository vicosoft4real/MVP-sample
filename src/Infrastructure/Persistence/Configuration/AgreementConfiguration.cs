using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class AgreementConfiguration: IEntityTypeConfiguration<Agreement>
{
    public void Configure(EntityTypeBuilder<Agreement> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Expiration).IsRequired();
        builder.Property(x => x.EffectiveDate).IsRequired();
        builder.Property(x => x.NewPrice).HasPrecision(2).IsRequired();
        builder.Property(x => x.ProductPrice).HasPrecision(2).IsRequired();
        builder.HasOne(x => x.Group);
        builder.HasOne(x => x.Product);
        builder.HasOne(x => x.User);
    }
}