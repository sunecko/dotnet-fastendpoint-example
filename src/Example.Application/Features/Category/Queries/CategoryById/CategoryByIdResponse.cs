namespace Example.Application.Features.Category.Queries.CategoryById;

public record CategoryByIdResponse
{
    public string Name { get; init; }
    public string Description { get; init; }
    public string ImageUrl { get; init; }
}