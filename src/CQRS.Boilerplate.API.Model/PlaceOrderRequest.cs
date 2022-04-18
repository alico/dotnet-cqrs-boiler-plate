using System.ComponentModel.DataAnnotations;

namespace CQRS.Boilerplate.API.Model
{
    public record PlaceOrderRequest
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}