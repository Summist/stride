using Stride.Domain.Catalog;

namespace Stride.Application.Catalog.Models;

public sealed class ProductFilter
{
    public int Page { get; init; } = 1;

    public int PageSize { get; init; } = 20;

    public string? Search { get; init; }

    public Guid? BrandId { get; init; }

    public Gender? Gender { get; init; }

    public Season? Season { get; init; }

    public decimal? MinPrice { get; init; }

    public decimal? MaxPrice { get; init; }

    public ProductSortBy SortBy { get; init; } = ProductSortBy.Newest;

    public bool Descending { get; init; } = true;
}
