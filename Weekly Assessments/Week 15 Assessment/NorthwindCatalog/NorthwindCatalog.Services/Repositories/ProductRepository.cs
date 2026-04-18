using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using NorthwindCatalog.Services.DTOs;
using NorthwindCatalog.Services.Models;
using NorthwindCatalog.Web.Repositories;


namespace NorthwindCatalog.Services.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly NorthwindContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(NorthwindContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            return await _context.Products
                .Include(p => p.Category)
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetByCategoryIdAsync(int categoryId)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.Category)
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ProductDto?> GetProductById(int id)
        {
            return await _context.Products
                .Where(p => p.ProductId == id)
                .Include(p => p.Category)
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CategorySummaryDto>> GetCategorySummariesAsync()
        {
            return await _context.Categories
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