using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stride.Domain.Catalog;

namespace Stride.Infrastructure.Persistence.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(Product.MaxNameLength)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(Product.MaxDescriptionLength)
            .IsRequired();

        builder.Property(x => x.Article)
            .HasMaxLength(Product.MaxArticleLength)
            .IsRequired();

        builder.HasIndex(x => x.Article)
            .IsUnique();

        builder.Property(x => x.Price)
            .HasPrecision(10, 2);

        builder
            .HasOne(x => x.Brand)
            .WithMany()
            .HasForeignKey(x => x.BrandId);

        builder
            .HasMany(x => x.Images)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);

        builder
            .HasMany(x => x.Variants)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);
    }
}
