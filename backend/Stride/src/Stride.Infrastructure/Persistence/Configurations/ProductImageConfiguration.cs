using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stride.Domain.Catalog;

namespace Stride.Infrastructure.Persistence.Configurations;

internal sealed class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.ToTable("product_images");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ImageUrl)
            .HasMaxLength(ProductImage.MaxImageUrlLength)
            .IsRequired();
    }
}
