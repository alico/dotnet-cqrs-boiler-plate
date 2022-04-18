using System.ComponentModel.DataAnnotations;
public record PlaceOrderRequest
{
    [Required]
    public Guid ProductId { get; set; }

    [Required]
    public Guid CustomerId { get; set; }

    [Required]
    public int Quantity { get; set; }
}