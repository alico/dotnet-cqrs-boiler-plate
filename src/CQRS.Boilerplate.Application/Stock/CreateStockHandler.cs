using CQRS.Boilerplate.Domain.Contracts;
using CQRS.Boilerplate.Domain.Models;
using MediatR;

namespace CQRS.Boilerplate.Application.Stock.Commands
{
    public class CreateStockHandler : IRequestHandler<CreateStockCommand, Unit>
    {
        private readonly ICommandDBContext _context;
        public CreateStockHandler(ICommandDBContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateStockCommand command, CancellationToken cancellationToken)
        {
            var stock = new Domain.Models.Stock(command.ProductId, command.Quantity);
            await _context.Stocks.AddAsync(stock, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
