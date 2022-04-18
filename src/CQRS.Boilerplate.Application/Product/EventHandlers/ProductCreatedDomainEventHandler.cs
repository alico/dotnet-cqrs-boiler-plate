using CQRS.Boilerplate.Application.Common.Models;
using CQRS.Boilerplate.Application.Product.Commands;
using CQRS.Boilerplate.Application.Stock.Commands;
using CQRS.Boilerplate.Domain.Contracts;
using CQRS.Boilerplate.Domain.Enums;
using CQRS.Boilerplate.Domain.Events;
using CQRS.Boilerplate.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace CQRS.Boilerplate.Application.Order.EventHandlers
{
    public class ProductCreatedDomainEventHandler : INotificationHandler<DomainEventNotification<ProductCreatedEvent>>
    {
        private readonly ICommandDBContext _context;
        private readonly ISender _sender;

        public ProductCreatedDomainEventHandler(ICommandDBContext context, ISender sender)
        {
            _context = context;
            _sender = sender;
        }

        public async Task Handle(DomainEventNotification<ProductCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var product = notification.DomainEvent.Product;
            var stock = new CreateStockCommand()
            {
                ProductId = product.Id,
                Quantity = notification.DomainEvent.Quantity
            };

            await _sender.Send(stock,cancellationToken);
        }
    }
}
