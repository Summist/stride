using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stride.Domain.Catalog;

namespace Stride.Infrastructure.Persistence.Configurations;

internal sealed class SizeConfiguration : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> builder)
    {
        builder.ToTable("sizes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.EuSize)
            .HasPrecision(4, 1);

        builder.Property(x => x.UsSize)
            .HasPrecision(4, 1);

        builder.Property(x => x.UkSize)
            .HasPrecision(4, 1);

        builder.Property(x => x.FootLengthCm)
            .HasPrecision(4, 1);

        builder
            .HasMany(x => x.Variants)
            .WithOne(x => x.Size)
            .HasForeignKey(x => x.SizeId);
    }
}
