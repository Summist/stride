using Stride.Domain.Primitives;

namespace Stride.Domain.Catalog;

public sealed class Brand : EntityBase
{
    public const int MaxNameLength = 100;

    public required string Name { get; set; }

    public bool IsActive { get; set; }
}
