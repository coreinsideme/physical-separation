using BLL.Entities;
using Web.Dtos;
using Web.Interfaces;

namespace Web.Mappers
{
    public class CategoryMapper : IMapper<Category, CategoryDto>
    {
        public CategoryDto MapToDto(Category entity) => new CategoryDto { Name = entity.Name, ParentCategoryId = entity.ParentCategoryId, Image = entity.ToString() };

        public Category MapToEntity(CategoryDto dto) => new Category(dto.Name) { ParentCategoryId = dto.ParentCategoryId, Image = new Uri(dto.Image) };
    }
}
