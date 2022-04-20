using System.ComponentModel.DataAnnotations;
public record GetProductListRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}