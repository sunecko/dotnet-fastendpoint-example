using Example.Application.Features.Category.Queries.CategoryById;
using FastEndpoints;

namespace Example.Api.Endpoints.Category;

public class CategoryByIdEndpoint: Endpoint<CategoryByIdQuery, CategoryByIdResponse>
{
    public override void Configure()
    {
        Get("/category/{id}");
        Summary(x => x.Summary = "Get a category by id");
    }

    public override async Task HandleAsync(CategoryByIdQuery req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response, statusCode: StatusCodes.Status200OK);
    }
}