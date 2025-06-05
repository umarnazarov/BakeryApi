
// Student ID: 00013630

using BakeryApi.Data;
using BakeryApi.Dtos;
using BakeryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BakeryApi.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly BakeryDbContext _context;

    public ProductRepository(BakeryDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductDto>> GetAllWithCategoryAsync()
    {
        return await _context.Products
            .Include(p => p.Category)
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryId = p.CategoryId,
                Category = p.Category == null ? null : new CategoryDto
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name
                }
            })
            .ToListAsync();
    }

    public async Task<ProductDto?> GetByIdWithCategoryAsync(int id)
    {
        var product = await _context.Products
            .Include(p => p.Category)
            .Where(p => p.Id == id)
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryId = p.CategoryId,
                Category = p.Category == null ? null : new CategoryDto
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name
                }
            })
            .FirstOrDefaultAsync();

        return product;
    }
}
