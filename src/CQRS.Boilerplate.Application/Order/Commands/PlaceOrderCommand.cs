using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Boilerplate.Application.Order.Commands
{
    public class PlaceOrderCommand : IRequest<Guid>
    {
        public Guid ProductId { get; init; }
        public Guid CustomerId { get; init; }
        public int Quantity { get; init; }

        public PlaceOrderCommand()
        {

        }

        public PlaceOrderCommand(Guid customerId, Guid productId, int quantity)
        {
            ProductId = productId;
            CustomerId = customerId;
            Quantity = quantity;
        }
    }
}
