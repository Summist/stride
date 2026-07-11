namespace Stride.Application.Catalog.Models;

public sealed record ProductSizeDto(
    Guid Id,
    decimal EuSize,
    decimal UsSize,
    decimal UkSize,
    decimal FootLengthCm,
    int AvailableQuantity);
