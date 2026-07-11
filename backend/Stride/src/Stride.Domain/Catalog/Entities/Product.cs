using Stride.Domain.Primitives;

namespace Stride.Domain.Catalog;

public sealed class Product : AuditableEntityBase
{
    public const int MaxNameLength = 100;
    public const int MaxDescriptionLength = 500;
    public const int MaxArticleLength = 50;

    public ICollection<ProductImage> Images { get; set; } = [];


    public required string Name { get; set; }

    public required string Description { get; set; }


    public required string Article { get; set; }


    public decimal Price { get; set; }


    public Guid BrandId { get; set; }

    public Brand Brand { get; set; } = null!;


    public Gender Gender { get; set; }

    public ProductStatus Status { get; set; }

    public Season Season { get; set; }


    public ICollection<ProductVariant> Variants { get; set; } = [];


    public bool IsActive { get; set; }
}
