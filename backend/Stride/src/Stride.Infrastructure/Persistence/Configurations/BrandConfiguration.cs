using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stride.Domain.Catalog;

namespace Stride.Infrastructure.Persistence.Configurations;

internal sealed class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("brands");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(Brand.MaxNameLength)
            .IsRequired();

        builder.HasIndex(x => x.Name)
            .IsUnique();
    }
}
