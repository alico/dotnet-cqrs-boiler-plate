using CQRS.Boilerplate.Domain.Common;
using CQRS.Boilerplate.Domain.Models;

namespace CQRS.Boilerplate.Domain.Events
{
    public class StockRunOutEvent : DomainEvent
    {
        public Stock Stock { get; internal set; }

        public StockRunOutEvent(Stock stock)
        {
            Stock = stock;
        }
    }
}
