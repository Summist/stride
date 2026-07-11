namespace Stride.Application.Catalog.Models;

public sealed record ProductDto(
    Guid Id,
    string? ImageUrl,
    string Name,
    decimal Price);
