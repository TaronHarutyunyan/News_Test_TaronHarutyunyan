using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using News_Test_TaronHarutyunyan.ModelsDto;
using News_Test_TaronHarutyunyan.Services;
using System;

namespace News_Test_TaronHarutyunyan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        readonly INewsService _service;
        readonly ILogger<NewsController> _logger;
        public NewsController(INewsService service,ILogger<NewsController> logger)
        {
            _service = service;
            _logger = logger;
        }
        [HttpDelete]
        public IActionResult DeleteNews(int id)
        {
            _service.DeleteNews(id);
            _logger.LogInformation($"News by {id} Id Deleted");
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateNews(NewsDto newsDto,int id)
        {
            _service.UpdateNews(newsDto,id);
            _logger.LogInformation($"News by {id} Id Updated");
            return Ok();
        }
        [HttpPost]
        public IActionResult CreateNews(NewsDto newsDto)
        {
            _service.CreateNews(newsDto);
            _logger.LogInformation("News Created");
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllNews()
        {
           return Ok(_service.GetAllNews());
        }
        [HttpGet("{categoryId}")]
        public IActionResult GetNewsByCategoryId(int categoryId)
        {
            return Ok(_service.GetNewsByCategory(categoryId));
        }
        [HttpGet("{searchText}/search")]
        public IActionResult GetNewsByText(string searchText)
        {
            var result = _service.GetNewsByText(searchText);
            return Ok(result);
        }
        [HttpGet("{firstdate}/{seconddate}")]
        public IActionResult GetNewsByDate(DateTime firstdate,DateTime seconddate)
        {
            var result =_service.GetNewsByDate(firstdate,seconddate);
            return Ok(result);  
        }
    }
}
