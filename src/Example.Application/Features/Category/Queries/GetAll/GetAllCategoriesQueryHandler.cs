using Example.Application.Common;
using Example.Application.Dtos;
using Example.Application.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Example.Application.Features.Category.Queries.GetAll;

public class GetAllCategoriesQueryHandler: BaseQueryHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
{
    private readonly ILogger<GetAllCategoriesQueryHandler> _logger;
    
    public GetAllCategoriesQueryHandler(
        IContext context,
        ILogger<GetAllCategoriesQueryHandler> logger) : base(context)
    {
        _logger = logger;
    }
    
    public override async Task<IEnumerable<CategoryDto>> ExecuteAsync(GetAllCategoriesQuery command, CancellationToken ct = default)
    {
        var categories = await Context.Categories
            .AsNoTracking()
            .Select(x => x.ToCategoryDto())
            .ToListAsync(ct);
        
        _logger.LogInformation($"{categories.Count} items found.");
        
        return categories;
    }
}