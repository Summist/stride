using Stride.Domain.Primitives;

namespace Stride.Domain.Catalog;

public sealed class ProductImage : EntityBase
{
    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;


    public required string ImageUrl { get; set; }

    public int SortOrder { get; set; }
}
