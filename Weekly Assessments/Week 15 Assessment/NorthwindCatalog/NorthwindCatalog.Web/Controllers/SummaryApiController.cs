using Microsoft.AspNetCore.Mvc;
using NorthwindCatalog.Web.Repositories;

namespace NorthwindCatalog.Web.Controllers
{
    [ApiController]
    [Route("api/summary")]
    public class SummaryApiController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public SummaryApiController(IProductRepository repo)
        {
            _repo = repo;
        }

        // ✅ Category summary
        [HttpGet]
        public async Task<IActionResult> GetSummary()
        {
            var data = await _repo.GetCategorySummariesAsync();
            return Ok(data);
        }
    }
}