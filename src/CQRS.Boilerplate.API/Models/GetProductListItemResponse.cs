using System.ComponentModel.DataAnnotations;
public record GetProductListItemResponse
{
    public Guid Id { get; set; }
    public string Name { get; init; }
    public string SKU { get; init; }
    public int Quantity { get; init; }
}