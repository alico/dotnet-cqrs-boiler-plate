using CQRS.Boilerplate.Domain.Common;
using CQRS.Boilerplate.Domain.Models;

namespace CQRS.Boilerplate.Domain.Events
{
    public class CustomerCreatedEvent: DomainEvent
    {
      public Customer Customer { get; internal set; }

        public CustomerCreatedEvent(Customer customer)
        {
            Customer = customer;
        }
    }
}
