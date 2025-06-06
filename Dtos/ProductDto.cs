// Student ID: 00013630
namespace BakeryApi.Dtos;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public CategoryDto? Category { get; set; }
}