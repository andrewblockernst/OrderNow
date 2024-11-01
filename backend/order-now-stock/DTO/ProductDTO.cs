using System.ComponentModel.DataAnnotations;

public class ProductDTO
{
    [Required(ErrorMessage = "Name field is required")]
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
