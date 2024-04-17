using Example.Application.Features.Product.Command.Create;
using FastEndpoints;

namespace Example.Api.Endpoints.Product;

public class CreateProductEndpoint: Endpoint<CreateProductCommand, EmptyResponse>
{
    public override void Configure()
    {
        Post("/product");
        Summary(x => x.Summary = "Create a new product");
    }

    public override async Task HandleAsync(CreateProductCommand req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response, statusCode: StatusCodes.Status201Created);
    }
}