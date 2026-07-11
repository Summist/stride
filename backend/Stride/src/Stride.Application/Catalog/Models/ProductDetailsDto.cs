using Stride.Domain.Catalog;

namespace Stride.Application.Catalog.Models;

public sealed record ProductDetailsDto(
    Guid Id,
    IReadOnlyCollection<ProductImageDto> Images,
    string Name,
    string Description,
    string Brand,
    decimal Price,
    string Article,
    Gender Gender,
    Season Season,
    IReadOnlyCollection<ProductSizeDto> Sizes);
