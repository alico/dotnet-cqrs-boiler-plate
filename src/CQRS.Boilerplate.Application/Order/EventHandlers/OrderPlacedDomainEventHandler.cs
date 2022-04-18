using CQRS.Boilerplate.Application.Common.Models;
using CQRS.Boilerplate.Domain.Contracts;
using CQRS.Boilerplate.Domain.Enums;
using CQRS.Boilerplate.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace CQRS.Boilerplate.Application.Order.EventHandlers
{
    public class OrderPlacedDomainEventHandler : INotificationHandler<DomainEventNotification<OrderPlacedEvent>>
    {
        private readonly ICommandDBContext _context;
        public OrderPlacedDomainEventHandler(ICommandDBContext context)
        {
            _context = context;
        }

        public async Task Handle(DomainEventNotification<OrderPlacedEvent> notification, CancellationToken cancellationToken)
        {
            var order = notification.DomainEvent.Order;
            var currentStock = await _context.Stocks.FirstOrDefaultAsync(x => x.ProductId == order.ProductId);
            
            if(currentStock is null || order.Quantity > currentStock.Quantity)
            {
                order.Status = (short)OrderStatus.Declined;
            }
            else
            {
                currentStock.Quantity -= order.Quantity;
                order.Status = (short)OrderStatus.Approved;
            }

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
