using System.ComponentModel.DataAnnotations;
public record CreateProductRequest
{
    [Required]
    [StringLength(50)]
    public string Name { get; init; }

    [Required]
    [StringLength(100)]
    public string SKU { get; init; }

    [Required]
    public int Quantity { get; init; }
}