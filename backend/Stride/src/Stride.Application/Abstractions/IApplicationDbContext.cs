using Microsoft.EntityFrameworkCore;
using Stride.Domain.Catalog;

namespace Stride.Application.Abstractions;

public interface IApplicationDbContext
{
    DbSet<Brand> Brands { get; }

    DbSet<Product> Products { get; }

    DbSet<ProductImage> ProductImages { get; }

    DbSet<ProductVariant> ProductVariants { get; }

    DbSet<Size> Sizes { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
