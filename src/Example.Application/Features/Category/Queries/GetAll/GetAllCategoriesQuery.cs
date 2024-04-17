using Example.Application.Dtos;
using FastEndpoints;

namespace Example.Application.Features.Category.Queries.GetAll;

public record GetAllCategoriesQuery : ICommand<IEnumerable<CategoryDto>>
{
    public int Xd { get; set; }
}