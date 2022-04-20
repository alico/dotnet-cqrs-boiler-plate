using CQRS.Boilerplate.Application.Common.Models;
using CQRS.Boilerplate.Application.Stock.Commands;
using CQRS.Boilerplate.Domain.Contracts;
using CQRS.Boilerplate.Domain.Enums;
using CQRS.Boilerplate.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace CQRS.Boilerplate.Application.Order.EventHandlers
{
    public class OrderPlacedDomainEventHandler : INotificationHandler<DomainEventNotification<OrderPlacedEvent>>
    {
        private readonly ISender _sender;
        public OrderPlacedDomainEventHandler(ISender sender)
        {
            _sender = sender;
        }

        public async Task Handle(DomainEventNotification<OrderPlacedEvent> notification, CancellationToken cancellationToken)
        {
            var order = notification.DomainEvent.Order;
            var updateStockCommand = new UpdateStockCommand()
            {
                ProductId = notification.DomainEvent.Order.ProductId,
                Quantity = notification.DomainEvent.Order.Quantity,
            };

            await _sender.Send(updateStockCommand);
        }
    }
}
