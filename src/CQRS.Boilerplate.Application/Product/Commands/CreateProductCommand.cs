using MediatR;

namespace CQRS.Boilerplate.Application.Product.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; init; }
        public string SKU { get; init; }
        public int Quantity { get; init; }
        public CreateProductCommand()
        {

        }

        public CreateProductCommand(string name, string sku, int quantity)
        {
            Name = name;
            SKU = sku;
            Quantity = quantity;
        }
    }
}
