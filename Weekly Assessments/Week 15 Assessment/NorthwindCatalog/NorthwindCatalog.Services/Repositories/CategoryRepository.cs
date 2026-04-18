using Microsoft.EntityFrameworkCore;
using NorthwindCatalog.Services.DTOs;
using NorthwindCatalog.Services.Models;
using NorthwindCatalog.Web.Repositories;

namespace NorthwindCatalog.Services.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NorthwindContext _context;

        public CategoryRepository(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories
                .Where(c => c.CategoryName != "Furniture")
                .ToListAsync();
        }

        public async Task<IEnumerable<CategorySummaryDto>> GetCategorySummariesAsync()
        {
            return await _context.Categories
                .Include(c => c.Products)
                .Select(c => new CategorySummaryDto
                {
                    CategoryName = c.CategoryName,
                    ProductCount = c.Products.Count(),

                    AvgPrice = c.Products.Any()
                        ? c.Products.Average(p => p.UnitPrice ?? 0)
                        : 0,

                    MostExpensiveProduct = c.Products
                        .OrderByDescending(p => p.UnitPrice)
                        .Select(p => p.ProductName)
                        .FirstOrDefault()
                })
                .ToListAsync();
        }
    }
}