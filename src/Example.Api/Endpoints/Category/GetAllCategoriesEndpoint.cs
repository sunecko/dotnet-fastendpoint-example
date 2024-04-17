using Example.Application.Dtos;
using Example.Application.Features.Category.Queries.GetAll;
using FastEndpoints;

namespace Example.Api.Endpoints.Category;

public class GetAllCategoriesEndpoint: Endpoint<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
{
    public override void Configure()
    {
        Post("/category/all");
        Summary(x => x.Summary = "Get all categories");
    }

    public override async Task HandleAsync(GetAllCategoriesQuery req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response, statusCode: StatusCodes.Status200OK);
    }
}