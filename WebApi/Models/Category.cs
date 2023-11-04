using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models;

public class Category
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    public string  Name { get; set; }
    
    [DataType(DataType.Text)]
    public string  Description { get; set; }

    public Guid? ProductId { get; set; }
    public Product? Product { get; set; }
}