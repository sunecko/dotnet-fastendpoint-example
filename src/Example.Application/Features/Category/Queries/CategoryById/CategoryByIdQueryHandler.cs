using Example.Application.Common;
using Example.Application.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Example.Application.Features.Category.Queries.CategoryById;

public class CategoryByIdQueryHandler: BaseQueryHandler<CategoryByIdQuery, CategoryByIdResponse>
{
    private readonly ILogger<CategoryByIdQueryHandler> _logger;
   
    public CategoryByIdQueryHandler(
        IContext context,
        ILogger<CategoryByIdQueryHandler> logger): base(context)
    {
        _logger = logger;
    }
    
    public override async Task<CategoryByIdResponse> ExecuteAsync(CategoryByIdQuery query, CancellationToken ct = default)
    {
        var category = await Context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == query.Id, ct);
        
        if (category is null)
        {
            _logger.LogError($"Category with id -> {query.Id} not found.");
            ThrowError("Category not found", StatusCodes.Status404NotFound);
        }

        return category.ToCategoryByIdResponse();
    }
}