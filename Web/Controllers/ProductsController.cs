using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using BLL.Entities;
using Web.Interfaces;
using Web.Dtos;

namespace Web.Controllers
{
    [Route("api/products")]
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

        [HttpGet]
        public IActionResult ListProducts(int id, [FromQuery]int pageSize = 10, [FromQuery] int pageNumber = 0)
        {
            return Ok(_productService.List(id, pageSize, pageNumber));
        }

        [HttpPost()]
        public IActionResult AddProduct(ProductDto dto)
        {
            var product = _mapper.MapToEntity(dto);
            _productService.Add(product);

            return Ok();
        }

        [HttpPut()]
        public IActionResult UpdateProduct(ProductDto dto)
        {
            var product = _mapper.MapToEntity(dto);
            _productService.Update(product);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.Delete(id);

            return Ok();
        }
    }
}
