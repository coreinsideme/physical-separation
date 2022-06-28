using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using BLL.Entities;
using Web.Interfaces;
using Web.Dtos;

namespace Web.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;
        private readonly IMapper<Product, ProductDto> _mapper;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger, IMapper<Product, ProductDto> mapper)
        {
            _productService = productService;
            _logger = logger;
            _mapper = mapper;
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

            return Ok();
        }

        [HttpDelete("products/{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            _productService.Delete(productId);

            return Ok();
        }
    }
}
