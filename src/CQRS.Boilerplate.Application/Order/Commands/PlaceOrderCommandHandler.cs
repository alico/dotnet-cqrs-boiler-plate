using CQRS.Boilerplate.Domain.Contracts;
using CQRS.Boilerplate.Domain.Enums;
using CQRS.Boilerplate.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Boilerplate.Application.Order.Commands
{
    public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, Guid>
    {
        private readonly ICommandDBContext _context;
        public PlaceOrderCommandHandler(ICommandDBContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(PlaceOrderCommand command, CancellationToken cancellationToken)
        {
            var order = new Domain.Models.Order(command.ProductId, command.CustomerId, command.Quantity, (short)OrderStatus.Placed);
            await _context.Orders.AddAsync(order, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
