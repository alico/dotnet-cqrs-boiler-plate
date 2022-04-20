using CQRS.Boilerplate.Domain.Common;
using CQRS.Boilerplate.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Boilerplate.Domain.Models
{
    public class Order : BaseEntity<Guid>, IHasDomainEvent
    {
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public short Status { get; set; }

        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        public Order(Guid productId, Guid customerId, int quantity, short status)
        {
            ProductId = productId;
            CustomerId = customerId;
            Quantity = quantity;
            Status = status;

            if(status == (short)OrderStatus.Placed)
                DomainEvents.Add(new Domain.Events.OrderPlacedEvent(this));
        }
    }
}
