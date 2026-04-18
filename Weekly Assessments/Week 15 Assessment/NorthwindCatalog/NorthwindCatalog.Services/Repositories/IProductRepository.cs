using NorthwindCatalog.Services.DTOs;
using NorthwindCatalog.Services.DTOs;
namespace NorthwindCatalog.Web.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<IEnumerable<ProductDto>> GetByCategoryIdAsync(int categoryId);
        Task<ProductDto?> GetProductById(int id);
        Task<IEnumerable<CategorySummaryDto>> GetCategorySummariesAsync();
    }
}