using BLL.Entities;
using Web.Dtos;
using Web.Interfaces;

namespace Web.Mappers
{
    public class ProductMapper : IMapper<Product, ProductDto>
    {
        public ProductDto MapToDto(Product entity) => new ProductDto()
        {
            Name = entity.Name,
            CategoryId = entity.CategoryId,
            Amount = entity.Amount,
            Price = entity.Price,
            Description = entity.Description,
            Image = entity.Image.ToString()
        };

        public Product MapToEntity(ProductDto dto) => new Product(dto.Name)
        {
            Amount = dto.Amount,
            Name = dto.Name,
            Price = dto.Price,
            CategoryId = dto.CategoryId,
            Description = dto.Description,
            Image = new Uri(dto.Image)
        };
    }
}
