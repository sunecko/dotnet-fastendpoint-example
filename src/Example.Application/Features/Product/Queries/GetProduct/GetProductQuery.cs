using Example.Application.Dtos;
using FastEndpoints;

namespace Example.Application.Features.Product.Queries.GetProduct;

public record GetProductQuery: ICommand<IEnumerable<ProductDto>>
{
    public long? Id { get; set; }
    public string? Name { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
}