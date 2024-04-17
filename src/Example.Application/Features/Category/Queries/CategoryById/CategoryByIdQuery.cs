using FastEndpoints;

namespace Example.Application.Features.Category.Queries.CategoryById;

public record CategoryByIdQuery: ICommand<CategoryByIdResponse>
{
    public long Id { get; set; } 
}