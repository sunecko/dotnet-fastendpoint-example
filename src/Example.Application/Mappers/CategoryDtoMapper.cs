using Example.Application.Dtos;
using Example.Application.Features.Category.Queries.CategoryById;
using Example.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Example.Application.Mappers;

[Mapper]
public static partial class CategoryMapper
{
    public static partial CategoryDto ToCategoryDto(this Category source);
    public static partial CategoryByIdResponse ToCategoryByIdResponse(this Category source);
}