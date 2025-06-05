// Student ID: 00013630
namespace BakeryApi.Dtos;

public class ProductCreateDto
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
}
