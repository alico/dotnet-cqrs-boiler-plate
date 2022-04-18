using System.ComponentModel.DataAnnotations;
public record AddNewCustomerRequest
{
    [Required]
    [StringLength(50)]
    public string Name { get; init; }

    [Required]
    [StringLength(100)]
    public string Email { get; init; }
}