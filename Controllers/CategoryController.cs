// Student ID: 00013630
using BakeryApi.Models;
using BakeryApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using BakeryApi.Dtos;

namespace BakeryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IGenericRepository<Category> _repo;

    public CategoryController(IGenericRepository<Category> repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _repo.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var item = await _repo.GetByIdAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromServices] IGenericRepository<Product> productRepo, CategoryCreateDto dto)
    {
        var category = new Category { Name = dto.Name };

        if (dto.ProductIds != null && dto.ProductIds.Any())
        {
            var products = await productRepo.GetAllAsync();
            category.Products = products.Where(p => dto.ProductIds.Contains(p.Id)).ToList();
        }

        var created = await _repo.AddAsync(category);
        return Ok(created);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Category category)
    {
        if (id != category.Id) return BadRequest();
        return Ok(await _repo.UpdateAsync(category));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _repo.DeleteAsync(id));
}
