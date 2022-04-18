using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Boilerplate.Domain.Models
{
    public class Stock : BaseEntity<Guid>
    {
        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public Stock()
        {

        }

        public Stock(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
