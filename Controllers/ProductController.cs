// Student ID: 00013630
using Microsoft.AspNetCore.Mvc;
using BakeryApi.Dtos;
using BakeryApi.Models;
using BakeryApi.Repositories;

namespace BakeryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repo;

    public ProductController(IProductRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _repo.GetAllWithCategoryAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var product = await _repo.GetByIdWithCategoryAsync(id);
        return product == null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Post(ProductCreateDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            CategoryId = dto.CategoryId
        };

        var created = await _repo.AddAsync(product);
        var createdDto = await _repo.GetByIdWithCategoryAsync(created.Id);
        return Ok(createdDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
        => Ok(await _repo.DeleteAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, ProductCreateDto dto)
    {
        var existingProduct = await _repo.GetByIdAsync(id);
        if (existingProduct == null)
            return NotFound();

        existingProduct.Name = dto.Name;
        existingProduct.Price = dto.Price;
        existingProduct.CategoryId = dto.CategoryId;

        await _repo.UpdateAsync(existingProduct);

        var updatedDto = await _repo.GetByIdWithCategoryAsync(id);
        return Ok(updatedDto);
    }

}


