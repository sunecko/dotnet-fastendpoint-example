using Example.Application.Common;
using Example.Application.Dtos;
using Example.Application.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Example.Application.Features.Product.Queries.GetProduct;

public class GetProductQueryHandler: BaseQueryHandler<GetProductQuery, IEnumerable<ProductDto>>
{
    private readonly ILogger<GetProductQueryHandler> _logger;

    public GetProductQueryHandler(
        IContext context,
        ILogger<GetProductQueryHandler> logger): base(context)
    {
        _logger = logger;
    }

    public override async Task<IEnumerable<ProductDto>> ExecuteAsync(GetProductQuery query, CancellationToken ct = default)
    {
        var productsQuery = Context.Products
            .AsNoTracking()
            .Include(x => x.Category)
            .AsQueryable();

        if (query.Id != null)
        {
            productsQuery = productsQuery.Where(x => x.Id == query.Id);
        }

        if (!string.IsNullOrEmpty(query.Name))
        {
            productsQuery = productsQuery.Where(x => x.Name.Contains(query.Name, StringComparison.CurrentCultureIgnoreCase));
        }

        if (query.MaxPrice != null)
        {
            productsQuery = productsQuery.Where(x => x.Price <= query.MaxPrice);
        }

        if (query.MinPrice != null)
        {
            productsQuery = productsQuery.Where(x => x.Price >= query.MinPrice);
        }

        var products = await productsQuery
            .Select(x => x.ToProductDto())
            .ToListAsync(ct);
        
        return products;
    }
}