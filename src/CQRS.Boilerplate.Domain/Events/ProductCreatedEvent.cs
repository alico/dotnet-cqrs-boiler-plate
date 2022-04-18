using CQRS.Boilerplate.Domain.Common;
using CQRS.Boilerplate.Domain.Models;

namespace CQRS.Boilerplate.Domain.Events
{
    public class ProductCreatedEvent: DomainEvent
    {
      public int Quantity { get; internal set; }
      public Product Product{ get; internal set; }

        public ProductCreatedEvent(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
