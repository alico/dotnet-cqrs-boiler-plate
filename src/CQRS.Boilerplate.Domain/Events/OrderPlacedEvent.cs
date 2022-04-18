using CQRS.Boilerplate.Domain.Common;
using CQRS.Boilerplate.Domain.Models;

namespace CQRS.Boilerplate.Domain.Events
{
    public class OrderPlacedEvent: DomainEvent
    {
      public Order Order { get; internal set; }

        public OrderPlacedEvent(Order order)
        {
            Order = order;
        }
    }
}
