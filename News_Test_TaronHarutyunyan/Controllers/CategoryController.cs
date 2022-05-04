using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using News_Test_TaronHarutyunyan.ModelsDto;
using News_Test_TaronHarutyunyan.Services;

namespace News_Test_TaronHarutyunyan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly ICategoryService _service;
        readonly ILogger<CategoryController> _logger;
        public CategoryController(ICategoryService service, ILogger<CategoryController> logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryDto categoryDto)
        {
            if (categoryDto == null) return BadRequest("NULL");
            _service.CreateCategory(categoryDto);
            _logger.LogInformation("Category Created");
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            _service.DeleteCategory(id);
            _logger.LogInformation($"Category by {id} Id is Deleted");
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateCategory(CategoryDto categoryDto, int id)
        {
            _service.UpdateCategory(categoryDto, id);
            _logger.LogInformation($"Category by {id} Id is Updated");
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            return Ok(_service.GetAllCategories());
        }
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            return Ok(_service.GetCategory(id));
        }
    }
}
