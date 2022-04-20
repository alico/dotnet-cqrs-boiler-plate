using CQRS.Boilerplate.Domain.Common;
using CQRS.Boilerplate.Domain.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Boilerplate.Domain.Models
{
    public class Stock : BaseEntity<Guid>, IHasDomainEvent
    {
        private int _quantity;
        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value == 0)
                {
                    DomainEvents.Add(new StockRunOutEvent(this));
                }

                _quantity = value;
            }
        }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        public Stock(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
