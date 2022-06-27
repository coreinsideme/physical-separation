using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using BLL.Entities;
using Web.Dtos;
using Web.Interfaces;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly IMapper<Category, CategoryDto> _mapper;
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService, ILogger<CategoriesController> logger, IMapper<Category, CategoryDto> mapper)
        {
            _categoryService = categoryService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListCategories()
        {
            return Ok(_categoryService.List());
        }

        [HttpPost()]
        public IActionResult AddCategory(CategoryDto dto)
        {
            var category = _mapper.MapToEntity(dto);
            _categoryService.Add(category);

            return Ok();
        }

        [HttpPut()]
        public IActionResult UpdateCategory(CategoryDto dto)
        {
            var category = _mapper.MapToEntity(dto);
            _categoryService.Update(category);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.Delete(id);

            return Ok();
        }
    }
}