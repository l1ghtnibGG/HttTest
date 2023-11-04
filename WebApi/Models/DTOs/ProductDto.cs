namespace WebApi.Models.DTOs;

public class ProductDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public double Weight { get; set; }
    
    public List<Category>? Categories { get; set; } = new();
}