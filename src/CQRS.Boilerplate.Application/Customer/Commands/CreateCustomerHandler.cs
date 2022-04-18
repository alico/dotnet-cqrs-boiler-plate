using CQRS.Boilerplate.Domain.Contracts;
using CQRS.Boilerplate.Domain.Events;
using MediatR;

namespace CQRS.Boilerplate.Application.Customer.Commands
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly ICommandDBContext _context;
        public CreateCustomerHandler(ICommandDBContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = new Domain.Models.Customer()
            {
                Name = command.Name,
                Email = command.Email,
            };

            customer.DomainEvents.Add(new CustomerCreatedEvent(customer));

            await _context.Customers.AddAsync(customer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return customer.Id;
        }
    }
}
