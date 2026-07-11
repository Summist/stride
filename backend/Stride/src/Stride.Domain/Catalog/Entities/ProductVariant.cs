using Stride.Domain.Primitives;

namespace Stride.Domain.Catalog;

public sealed class ProductVariant : EntityBase
{
    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;

    
    public Guid SizeId { get; set; }

    public Size Size { get; set; } = null!;

    
    public int AvailableQuantity { get; set; }
}
