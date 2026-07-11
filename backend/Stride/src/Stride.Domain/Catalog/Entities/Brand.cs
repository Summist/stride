using Stride.Domain.Primitives;

namespace Stride.Domain.Catalog;

public sealed class Brand : EntityBase
{
    public required string Name { get; set; }

    public bool IsActive { get; set; }
}
