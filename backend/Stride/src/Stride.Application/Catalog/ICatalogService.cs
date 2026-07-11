using Stride.Application.Catalog.Models;

namespace Stride.Application.Catalog;

public interface ICatalogService
{
    Task<PagedList<ProductDto>> GetProductsAsync(
        ProductFilter filter,
        CancellationToken cancellationToken = default);

    Task<ProductDetailsDto> GetProductAsync(
        Guid productId,
        CancellationToken cancellationToken = default);
}
