using Example.Application.Features.Category.CreateCategory;
using FastEndpoints;

namespace Example.Api.Endpoints.Category;

public class CreateCategoryEndpoint: Endpoint<CreateCategoryCommand, EmptyResponse>
{
    public override void Configure()
    {
        Post("/category");
        Summary(x => x.Summary = "Create a new category");
    }

    public override async Task HandleAsync(CreateCategoryCommand req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response, statusCode: StatusCodes.Status201Created);
    }
}