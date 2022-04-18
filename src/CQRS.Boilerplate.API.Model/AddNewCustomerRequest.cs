using System.ComponentModel.DataAnnotations;

namespace CQRS.Boilerplate.API.Model
{
    public record AddNewCustomerRequest
    {
        [Required]
        [StringLength(50)]
        public string Name { get; init; }

        [Required]
        [StringLength(100)]
        public string Email { get; init; }
    }
}