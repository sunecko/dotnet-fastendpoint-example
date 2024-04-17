using Example.Application.Dtos;
using Example.Application.Features.Product.Queries.GetProduct;
using FastEndpoints;

namespace Example.Api.Endpoints.Product;

public class GetProductEndpoint: Endpoint<GetProductQuery, IEnumerable<ProductDto>>
{
    public override void Configure()
    {
        Get("/product");
        Summary(x => x.Summary = "Get product filtered");
    }

    public override async Task HandleAsync(GetProductQuery req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response, statusCode: StatusCodes.Status200OK);
    }
}