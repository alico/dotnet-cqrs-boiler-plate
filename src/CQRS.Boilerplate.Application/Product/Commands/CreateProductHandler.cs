using CQRS.Boilerplate.Domain.Contracts;
using CQRS.Boilerplate.Domain.Models;
using MediatR;

namespace CQRS.Boilerplate.Application.Product.Commands
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly ICommandDBContext _context;
        public CreateProductHandler(ICommandDBContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Domain.Models.Product(command.Name, command.SKU);
           

            product.DomainEvents.Add(new Domain.Events.ProductCreatedEvent(product, command.Quantity));
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
