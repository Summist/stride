using Microsoft.EntityFrameworkCore;
using Stride.Application.Abstractions;
using Stride.Application.Catalog.Models;
using Stride.Domain.Catalog;

namespace Stride.Application.Catalog;

internal sealed class CatalogService(
    IApplicationDbContext dbContext)
    : ICatalogService
{
    public async Task<PagedList<ProductDto>> GetProductsAsync(
        ProductFilter filter,
        CancellationToken cancellationToken = default)
    {
        IQueryable<Product> query = dbContext.Products
            .AsNoTracking()
            .Where(x => x.Status == ProductStatus.Active);

        if (!string.IsNullOrWhiteSpace(filter.Search))
        {
            query = query.Where(x =>
                x.Name.Contains(filter.Search) ||
                x.Description.Contains(filter.Search) ||
                x.Article.Contains(filter.Search));
        }

        if (filter.BrandId is not null)
        {
            query = query.Where(x => x.BrandId == filter.BrandId);
        }

        if (filter.Gender is not null)
        {
            query = query.Where(x => x.Gender == filter.Gender);
        }

        if (filter.Season is not null)
        {
            query = query.Where(x => x.Season == filter.Season);
        }

        if (filter.MinPrice is not null &&
            filter.MaxPrice is not null &&
            filter.MinPrice > filter.MaxPrice)
        {
            throw new ArgumentException(
                "Минимальная цена не может быть больше максимальной.");
        }

        if (filter.MinPrice is not null)
        {
            query = query.Where(x => x.Price >= filter.MinPrice);
        }

        if (filter.MaxPrice is not null)
        {
            query = query.Where(x => x.Price <= filter.MaxPrice);
        }

        query = filter.SortBy switch
        {
            ProductSortBy.Newest => filter.Descending
                ? query.OrderByDescending(x => x.CreatedAtUtc)
                : query.OrderBy(x => x.CreatedAtUtc),

            ProductSortBy.Price => filter.Descending
                ? query.OrderByDescending(x => x.Price)
                : query.OrderBy(x => x.Price),

            ProductSortBy.Name => filter.Descending
                ? query.OrderByDescending(x => x.Name)
                : query.OrderBy(x => x.Name),

            _ => query.OrderByDescending(x => x.CreatedAtUtc)
        };

        int totalCount = await query.CountAsync(cancellationToken);

        List<ProductDto> products = await query
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(x => new ProductDto(
                x.Id,
                x.Images
                    .OrderBy(i => i.SortOrder)
                    .Select(i => i.ImageUrl)
                    .FirstOrDefault() ?? string.Empty,
                x.Name,
                x.Price))
            .ToListAsync(cancellationToken);

        return new PagedList<ProductDto>
        {
            Items = products,
            Page = filter.Page,
            PageSize = filter.PageSize,
            TotalCount = totalCount,
            TotalPages = totalCount / filter.PageSize,
            HasNextPage = (totalCount - filter.Page * filter.PageSize) > 0,
            HasPreviousPage = filter.Page > 1
        };
    }

    public async Task<ProductDetailsDto> GetProductAsync(
        Guid productId,
        CancellationToken cancellationToken = default)
    {
        Product product = await dbContext.Products
            .AsNoTracking()
            .Include(x => x.Brand)
            .Include(x => x.Images)
            .Include(x => x.Variants)
                .ThenInclude(x => x.Size)
            .SingleOrDefaultAsync(x => x.Id == productId, cancellationToken)
            ?? throw new InvalidOperationException("Товар не найден");

        if (product.Status != ProductStatus.Active)
        {
            throw new InvalidOperationException("Товар не доступен");
        }

        return new ProductDetailsDto(
            Id: product.Id,
            Images: product.Images.Select(x => new ProductImageDto(
                ImageUrl: x.ImageUrl,
                SortOrder: x.SortOrder))
                .ToArray(),
            Name: product.Name,
            Description: product.Description,
            Brand: product.Brand.Name,
            Price: product.Price,
            Article: product.Article,
            Gender: product.Gender,
            Season: product.Season,
            Sizes: product.Variants.Select(x => new ProductSizeDto(
                Id: x.Id,
                EuSize: x.Size.EuSize,
                UsSize: x.Size.UsSize,
                UkSize: x.Size.UkSize,
                FootLengthCm: x.Size.FootLengthCm,
                AvailableQuantity: x.AvailableQuantity))
                .ToArray());
    }
}
