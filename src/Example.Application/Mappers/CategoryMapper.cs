using Example.Application.Features.Category.CreateCategory;
using Riok.Mapperly.Abstractions;

namespace Example.Application.Mappers;

[Mapper]
public static partial class CategoryDtoMapper
{
    public static partial Domain.Entities.Category ToCategoryEntity(this CreateCategoryCommand source);
}