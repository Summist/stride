using Stride.Domain.Primitives;

namespace Stride.Domain.Catalog;

public sealed class Size : EntityBase
{
    public decimal EuSize { get; set; }

    public decimal UsSize { get; set; }

    public decimal UkSize { get; set; }

    public decimal FootLengthCm { get; set; }


    public ICollection<ProductVariant> Variants { get; set; } = [];
}
