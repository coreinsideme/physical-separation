using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using BLL.Entities;
using Web.Interfaces;
using Web.Dtos;
using Web.Models;

namespace Web.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;
        private readonly IMapper<Product, ProductDto> _mapper;
        private readonly IRabbitMQProducer _rabbitMQ;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger, IMapper<Product, ProductDto> mapper, IRabbitMQProducer rabbitMQ)
        {
            _productService = productService;
            _logger = logger;
            _mapper = mapper;
            _rabbitMQ = rabbitMQ;
        }

        [HttpGet("categories/{categoryId}/products")]
        public IActionResult ListProducts(int categoryId, [FromQuery]int pageSize = 10, [FromQuery] int pageNumber = 0)
        {
            return Ok(_productService.List(categoryId, pageSize, pageNumber));
        }

        [HttpPost("products")]
        public IActionResult AddProduct(ProductDto dto)
        {
            var product = _mapper.MapToEntity(dto);
            _productService.Add(product);

            return Ok();
        }

        [HttpPut("products")]
        public IActionResult UpdateProduct(ProductDto dto)
        {
            var product = _mapper.MapToEntity(dto);
            _productService.Update(product);
            _rabbitMQ.SendMessage(new PriceChangeModel { Name = dto.Name, Price = dto.Price });

            return Ok();
        }

        [HttpDelete("products/{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            _productService.Delete(productId);

            return Ok();
        }

        [HttpGet("products/fake/{productId}")]
        public IActionResult GetMockData(int productId)
        {
            return Ok(new {
                Id = productId,
                Name = "Nike Air Jordan",
                CategoryName = "Shoes",
                Price = 199
            });
        }
    }
}
