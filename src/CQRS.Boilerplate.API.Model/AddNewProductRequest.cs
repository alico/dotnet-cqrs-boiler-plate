using System.ComponentModel.DataAnnotations;

namespace CQRS.Boilerplate.API.Model
{
    public record AddNewProductRequest
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
}