// Student ID: 00013630

using BakeryApi.Dtos;
using BakeryApi.Models;

namespace BakeryApi.Repositories;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<IEnumerable<ProductDto>> GetAllWithCategoryAsync();
    Task<ProductDto?> GetByIdWithCategoryAsync(int id);
}
