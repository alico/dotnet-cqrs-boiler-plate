using MediatR;

namespace CQRS.Boilerplate.Application.Stock.Commands
{
    public class UpdateStockCommand : IRequest<Unit>
    {
        public Guid ProductId { get; init; }
        public int Quantity { get; init; }
     
        public UpdateStockCommand()
        {

        }

        public UpdateStockCommand(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
