using MediatR;

namespace CQRS.Boilerplate.Application.Stock.Commands
{
    public class CreateStockCommand : IRequest<Unit>
    {
        public Guid ProductId { get; init; }
        public int Quantity { get; init; }
     
        public CreateStockCommand()
        {

        }

        public CreateStockCommand(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
