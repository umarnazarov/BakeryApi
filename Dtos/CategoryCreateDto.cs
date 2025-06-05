// Student ID: 00013630
namespace BakeryApi.Dtos;

public class CategoryCreateDto
{
    public string Name { get; set; } = null!;
    public List<int>? ProductIds { get; set; } = new();
}
