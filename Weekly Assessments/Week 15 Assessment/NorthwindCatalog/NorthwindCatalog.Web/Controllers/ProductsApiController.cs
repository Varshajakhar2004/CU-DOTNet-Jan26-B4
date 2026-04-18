using Microsoft.AspNetCore.Mvc;
using NorthwindCatalog.Services.DTOs; 
using NorthwindCatalog.Web.Repositories;

namespace NorthwindCatalog.Web.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsApiController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsApiController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("by-category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var data = await _repo.GetByCategoryIdAsync(categoryId);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _repo.GetProductById(id);
            if (data == null) return NotFound();

            return Ok(data);
        }
    }
}