using FastEndpoints;

namespace Example.Application.Features.Category.CreateCategory;

public record CreateCategoryCommand: ICommand<EmptyResponse>
{
    public string Name { get; init; }
    public string Description { get; init; }
    public string ImageUrl { get; init; }
}