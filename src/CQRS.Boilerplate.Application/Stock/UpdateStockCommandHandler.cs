using CQRS.Boilerplate.Domain.Contracts;
using CQRS.Boilerplate.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Boilerplate.Application.Stock.Commands
{
    public class UpdateStockCommandHandler : IRequestHandler<UpdateStockCommand, Unit>
    {
        private readonly ICommandDBContext _context;
        public UpdateStockCommandHandler(ICommandDBContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateStockCommand command, CancellationToken cancellationToken)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == command.ProductId);

            if (stock == null)
                throw new Exception("Stock not found");

            stock.Quantity -= command.Quantity;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
